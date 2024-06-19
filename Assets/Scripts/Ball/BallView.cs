using Physics;
using UnityEngine;

namespace Ball
{
	[RequireComponent(typeof(BallCollision))]
	public class BallView : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _effectPrefab;
		[SerializeField] private BouncedData _bouncedData;

		private BallEffect _effect;
		private Bounced _bounced;
		private BallCollision _ballCollision;

		private void Awake()
		{
			_ballCollision = GetComponent<BallCollision>();

			_effect = new BallEffect(_effectPrefab);
			_bounced = new Bounced(_ballCollision.Rigidbody, _bouncedData);
		}

		private void OnEnable() =>
			_ballCollision.EnterCollision += OnEnterCollision;

		private void OnDisable() =>
			_ballCollision.EnterCollision -= OnEnterCollision;

		private void FixedUpdate() => 
			_bounced.ClampHeight();

		private void OnEnterCollision(Vector3 contactPosition)
		{
			_bounced.BouncedOff(Vector3.up);
			_effect.PlayEffect(contactPosition);
		}
	}
}