using System;
using UnityEngine;

namespace Tower
{
	public class ObjectRotation
	{
		private readonly Transform _transform;
		private readonly float _speedRotation;

		public ObjectRotation(float speedRotation, Transform transform)
		{
			if (speedRotation <= 0)
				throw new ArgumentOutOfRangeException($"{nameof(speedRotation)}" +
				                                      $"It cannot be less than or equal to 0");

			_speedRotation = speedRotation;
			_transform = transform ?? throw new NullReferenceException($"{nameof(transform)} it cannot not null");
		}

		private Quaternion CalculateRotationY(float deltaX) => 
			Quaternion.Euler(_transform.eulerAngles + Vector3.down * deltaX);

		public void AddRotation(float deltaX)
		{
			float speedRotation = Time.deltaTime * _speedRotation;
			Quaternion currentRotation = _transform.rotation;
			Quaternion newRotation = CalculateRotationY(deltaX);

			_transform.rotation = Quaternion.Slerp(currentRotation, newRotation, speedRotation);
		}
	}
}