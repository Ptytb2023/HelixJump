using System;
using Ball;
using UnityEngine;

namespace Platforms
{
	[RequireComponent(typeof(Collider))]
	public class ExplosionTriggerByBall : MonoBehaviour
	{
		public event Action TriggerEnter;

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out BallView ball))
				TriggerEnter?.Invoke();
		}

		private void OnValidate()
		{
			GetComponent<Collider>().isTrigger = true;
		}
	}
}