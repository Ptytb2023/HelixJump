using Extension;
using UnityEngine;

namespace Platforms
{
	public abstract class SegmentPlatform : MonoBehaviour
	{
		private Rigidbody _rigidbody;

		private void Awake()
		{
			_rigidbody = gameObject.AddComponent<Rigidbody>();
			_rigidbody.isKinematic = true;
		}

		public void UnhookByExplosion(Vector3 position, float force, float radius, float delayDestroy = 0f)
		{
			transform.ClearParent();
			_rigidbody.detectCollisions = false;
			_rigidbody.isKinematic = false;

			_rigidbody.AddExplosionForce(force, position, radius);

			Destroy(gameObject, delayDestroy);
		}
	}
}