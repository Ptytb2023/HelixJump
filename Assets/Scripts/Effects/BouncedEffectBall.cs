using System;
using Physics;
using Structures;
using UnityEngine;

namespace Effects
{
	public class BouncedEffectBall
	{
		private readonly DataAnimationCurve _sizeCurve;
		private readonly Rigidbody _rigidbody;
		private readonly BouncedData _bouncedData;

		public BouncedEffectBall(Rigidbody rigidbody, BouncedData bouncedData, DataAnimationCurve sizeCurve)
		{
			if (rigidbody is null || bouncedData is null || sizeCurve is null)
				throw new NullReferenceException();

			_bouncedData = bouncedData;
			_rigidbody = rigidbody;
			_sizeCurve = sizeCurve;
		}

		public void TryApplyUpwardsScale(Transform mesh, Vector3 initialScale)
		{
			if (_rigidbody.velocity.y >= 0.0f)
			{
				mesh.localScale = initialScale;
				return;
			}

			float present = _rigidbody.velocity.y / _bouncedData.MaxHeight;

			Vector3 newScale = new()
			{
				x = _sizeCurve.CurveX.Evaluate(present),
				y = _sizeCurve.CurveY.Evaluate(present),
				z = _sizeCurve.CurveZ.Evaluate(present)
			};

			mesh.localScale = newScale;
		}
	}
}