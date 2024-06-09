using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ball
{
	public class BallEffect
	{
		private Queue<ParticleSystem> _effects;
		private ParticleSystem _effect;

		public BallEffect(ParticleSystem effect)
		{
			if (effect is null)
				throw new NullReferenceException($"{(ParticleSystem)null} it is not null");

			Initialization(effect);
		}

		private void Initialization(ParticleSystem effect)
		{
			_effect = Object.Instantiate(effect);
			_effect.Stop();
			_effect.gameObject.SetActive(false);
		}


		public void PlayEffect(Vector3 position)
		{
			_effect.transform.position = position;
			_effect.gameObject.SetActive(true);
			_effect.Play();
		}
	}

	
}