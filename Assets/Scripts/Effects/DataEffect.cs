using System;
using UnityEngine;

namespace Effects
{
	[Serializable]
	public class DataEffect
	{
		[field: SerializeField] public ParticleSystem ParticleEffect { get; private set; }
		[field: SerializeField] public EffectType EffectType { get; private set; }
	}
	
	public enum EffectType
	{
		CollisionEnter = 1,
		Dead = 2,
		Spot = 3,
	}
}