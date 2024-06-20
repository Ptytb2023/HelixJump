using System;
using UnityEngine;

namespace Structures
{
	[Serializable]
	public class DataAnimationCurve
	{
		[field: SerializeField] public AnimationCurve CurveX { get; private set; }
		[field: SerializeField] public AnimationCurve CurveY { get; private set; }
		[field: SerializeField] public AnimationCurve CurveZ { get; private set; }
	}
}