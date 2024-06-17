using System;
using Platforms;
using UnityEngine;

namespace Ball
{
	[RequireComponent(typeof(Collider), typeof(Rigidbody))]
	public class BallCollision : MonoBehaviour, IBallCollision
	{
		public event Action<Vector3> EnterCollision;

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent<Platform>(out Platform platform))
				EnterCollision?.Invoke(other.contacts[0].point);
		}
	}
}