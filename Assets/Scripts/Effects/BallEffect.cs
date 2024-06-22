using System;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

namespace Effects
{
	[Serializable]
	public class BallEffect
	{
		private Dictionary<EffectType, ParticleEffectsForLeanPool> _effects;
		
		public BallEffect(IEnumerable<DataEffect> dataEffects)
			=> Initialization(dataEffects);

		public BallEffect(params DataEffect[] dataEffects)
			=> Initialization(dataEffects);

		public void Initialization(IEnumerable<DataEffect> dataEffects)
		{
			if (dataEffects is null)
				throw new NullReferenceException(nameof(DataEffect));

			_effects = new Dictionary<EffectType, ParticleEffectsForLeanPool>();

			foreach (DataEffect effect in dataEffects)
			{
				EffectType effectType = effect.EffectType;
				ParticleEffectsForLeanPool particleEffect = effect.ParticleEffect;

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
			if (!_effects.TryGetValue(effectType, out ParticleEffectsForLeanPool effect))
				throw new ArgumentNullException($"{effectType} does not exist");

			ParticleEffectsForLeanPool spawn = LeanPool.Spawn(effect, position, Quaternion.identity, parrent);

			spawn.Effect.Play();
		}
	}
}