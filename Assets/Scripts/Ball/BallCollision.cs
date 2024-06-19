using System;
using Platforms;
using Unity.VisualScripting;
using UnityEngine;

namespace Ball
{
	[RequireComponent(typeof(Collider), typeof(Rigidbody))]
	public class BallCollision : MonoBehaviour, IBallCollision
	{
		[field: SerializeField] public Rigidbody Rigidbody { get; private set; }
		public event Action<Vector3> EnterCollision;

		private void Awake()
		{
			Rigidbody = GetComponent<Rigidbody>();
		}

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent<SegmentPlatform>(out SegmentPlatform platform))
				EnterCollision?.Invoke(other.contacts[0].point);
		}
	}
}