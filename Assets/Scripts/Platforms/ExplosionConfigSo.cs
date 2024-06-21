using UnityEngine;

namespace Platforms
{
	[CreateAssetMenu(
		fileName = nameof(ExplosionConfigSo),
		menuName = "ScriptObject/Data/" + nameof(ExplosionConfigSo),
		order = 51)]
	public class ExplosionConfigSo : ScriptableObject
	{
		[SerializeField] [Min(0f)] private float _delayDestroy;
		[SerializeField] [Min(0f)] private float _radius;
		[SerializeField] private float _force;

		public float Force => _force;
		public float Radius => _radius;
		public float DelayDestroy => _delayDestroy;
	}
}