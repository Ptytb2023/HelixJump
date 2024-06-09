using UnityEngine;

namespace Ball
{
	[RequireComponent(typeof(BallCollision))]
	public class BallView : MonoBehaviour
	{
		[SerializeField] private ParticleSystem _effectPrefab;
		
		private BallEffect _effect;
		private BallCollision _ballCollision;

		private void Awake()
		{
			_ballCollision = GetComponent<BallCollision>();
			_effect = new BallEffect(_effectPrefab);
		}

		private void OnEnable()
		{
			_ballCollision.EnterCollision += OnEnterCollision;
		}

		private void OnDisable()
		{
			_ballCollision.EnterCollision -= OnEnterCollision;
		}

		private void OnEnterCollision(Vector3 contactPosition) => 
			_effect.PlayEffect(contactPosition);
	}
}