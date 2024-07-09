using System;
using System.Collections.Generic;
using Cinemachine;
using Effects;
using Physics;
using UnityEngine;

namespace Ball
{
	[RequireComponent(typeof(CollisionBall), typeof(Rigidbody))]
	public class BallView : MonoBehaviour
	{
		[SerializeField] private List<DataEffect> _dataEffects;
		[SerializeField] private BouncedData _bouncedData;
		[SerializeField] private CinemachineImpulseSource _cinemachineImpulse;
		
		private BallEffect _effect;
		private Bounced _bounced;
		private CollisionBall _collisionBall;

		private const float OffsetForSpot = 0.01f;
		public event Action Dead;

		private void Awake()
		{
			_collisionBall = GetComponent<CollisionBall>();
			Rigidbody rigidbodyBall = GetComponent<Rigidbody>();

			_bounced = new Bounced(rigidbodyBall, _bouncedData);
			_effect = new BallEffect(_dataEffects);
		}

		private void OnEnable()
		{
			_collisionBall.CollisionEnter += OnCollisionEnter;
			_collisionBall.CollisionObstacleEnter += OnCollisionObstacleEnter;
		}

		private void OnDisable()
		{
			_collisionBall.CollisionEnter -= OnCollisionEnter;
			_collisionBall.CollisionObstacleEnter -= OnCollisionObstacleEnter;
		}

		private void FixedUpdate()
			=> _bounced.ClampHeight();

		private void OnCollisionEnter(Collision collision)
		{
			Vector3 position = _collisionBall.PointContact;
			Vector3 positionSpot = position + Vector3.up * OffsetForSpot;

			_bounced.BouncedOff(Vector3.up);
			
			_effect.PlayEffect(position, collision.transform, EffectType.CollisionEnter);
			_effect.PlayEffect(positionSpot, collision.transform, EffectType.Spot);
		}

		
		private void OnCollisionObstacleEnter()
			=> Die();

		private void Die()
		{
			_effect.PlayEffect(_collisionBall.PointContact, null, EffectType.Dead);
			_cinemachineImpulse.GenerateImpulse();
			
			Dead?.Invoke();
			Destroy(gameObject);
		}
	}
}