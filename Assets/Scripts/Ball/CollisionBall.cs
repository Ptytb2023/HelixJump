using System;
using Platforms;
using UnityEngine;

namespace Ball
{
	[RequireComponent(typeof(Collider), typeof(Rigidbody))]
	public class CollisionBall : MonoBehaviour, ICollisionBall
	{
		private Rigidbody _rigidbody;

		public event Action<Collision> CollisionEnter;
		public event Action CollisionObstacleEnter;

		public Vector3 PointContact { get; private set; }


		private void OnCollisionEnter(Collision other)
		{
			PointContact = other.contacts[0].point;

			if (other.gameObject.TryGetComponent(out ObstaclePlatform obstacle))
				CollisionObstacleEnter?.Invoke();
			else
				CollisionEnter?.Invoke(other);
		}

	}
}