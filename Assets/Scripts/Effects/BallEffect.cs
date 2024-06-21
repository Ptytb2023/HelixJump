using System;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Effects
{
	[Serializable]
	public class BallEffect
	{
		private Dictionary<EffectType, ParticleSystem> _effects;
		
		public BallEffect(IEnumerable<DataEffect> dataEffects)
			=> Initialization(dataEffects);

		public BallEffect(params DataEffect[] dataEffects)
			=> Initialization(dataEffects);

		public void Initialization(IEnumerable<DataEffect> dataEffects)
		{
			if (dataEffects is null)
				throw new NullReferenceException(nameof(DataEffect));

			_effects = new Dictionary<EffectType, ParticleSystem>();

			foreach (DataEffect effect in dataEffects)
			{
				EffectType effectType = effect.EffectType;
				ParticleSystem particleEffect = effect.ParticleEffect;

				if (!_effects.TryAdd(effectType, particleEffect))
					throw new ArgumentException();

				// SpawnEffect(particleEffect);
			}
		}


		private void SpawnEffect(ParticleSystem particleEffect)
		{
			ParticleSystem effect = LeanPool.Spawn(particleEffect);
			effect.gameObject.SetActive(false);
		}

		public void PlayEffect(Vector3 position, Transform parrent, EffectType effectType)
		{
			if (!_effects.TryGetValue(effectType, out ParticleSystem effect))
				throw new ArgumentNullException($"{effectType} does not exist");

			ParticleSystem spawn = Object.Instantiate(effect, position, Quaternion.identity, parrent);

			spawn.Play();
		}
	}
}