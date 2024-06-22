using System;
using System.Collections;
using Lean.Pool;
using UnityEngine;

namespace Effects
{
	[RequireComponent(typeof(ParticleSystem))]
	public class ParticleEffectsForLeanPool : MonoBehaviour, IPoolable
	{
		public ParticleSystem Effect { get; private set; }

		private void Awake() =>
			Effect = GetComponent<ParticleSystem>();


		// public void Play()
		// {
		// 	Effect.Play();
		// 	LeanPool.Despawn(this, Effect.time);
		// }

		private void OnDisable()
		{
			LeanPool.Despawn(this);
		}

		public void OnSpawn()
		{
		}


		public void OnDespawn()
		{
		}
	}
}