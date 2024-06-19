using UnityEngine;

namespace Physics
{
	public class Bounced
	{
		private readonly Rigidbody _rigidbody;
		private readonly BouncedData _bouncedData;

		public Bounced(Rigidbody rigidbody, BouncedData bouncedData)
		{
			_rigidbody = rigidbody;
			_bouncedData = bouncedData;
		}

		public void BouncedOff(Vector3 direction) =>
			_rigidbody.AddForce(direction * _bouncedData.Force, ForceMode.VelocityChange);

		public void ClampHeight()
		{
			Vector3 velocity = _rigidbody.velocity;

			_rigidbody.velocity = velocity.y >= 0f
					? Vector3.ClampMagnitude(velocity, _bouncedData.MaxHeight)
					: velocity;
		}
	}
}