using System;
using UnityEngine;

namespace Platforms
{
	public class Platform : MonoBehaviour
	{
		private ExplosionConfigSo _explosionConfigSo;
		private ExplosionTriggerByBall[] _triggersByBall;

		private SegmentPlatform[] _platforms;

		private void Awake()
		{
			_triggersByBall = GetComponentsInChildren<ExplosionTriggerByBall>();
			_platforms = GetComponentsInChildren<SegmentPlatform>();

			if (_platforms is null || _triggersByBall is null)
				throw new NullReferenceException();
		}

		private void OnEnable()
		{
			foreach (ExplosionTriggerByBall triggerByBall in _triggersByBall)
				triggerByBall.TriggerEnter += ApplyUnhookAllSegment;
		}

		private void OnDisable()
		{
			foreach (ExplosionTriggerByBall triggerByBall in _triggersByBall)
				triggerByBall.TriggerEnter -= ApplyUnhookAllSegment;
		}
	

	public void Init(ExplosionConfigSo explosionConfigSo) =>
		_explosionConfigSo = explosionConfigSo;

	private void ApplyUnhookAllSegment()
	{
		foreach (SegmentPlatform platform in _platforms)
		{
			float radius = _explosionConfigSo.Radius;
			float force = _explosionConfigSo.Force;
			float delayDestroy = _explosionConfigSo.DelayDestroy;

			platform.UnhookByExplosion(transform.position, force, radius, delayDestroy);
		}

		Destroy(gameObject);
	}
}

}