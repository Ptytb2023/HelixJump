using System;
using UnityEngine;

namespace Physics
{
	[Serializable]
	public class BouncedData
	{
		[field: SerializeField] public float MaxHeight { get; private set; }
		[field: SerializeField] public float Force { get; private set; }
	}
}