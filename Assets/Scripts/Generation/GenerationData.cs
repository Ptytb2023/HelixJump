using System.Collections.Generic;
using Extension;
using Platforms;
using UnityEngine;

namespace Generation
{
	[CreateAssetMenu(
		fileName = nameof(GenerationData),
		menuName = "ScriptObject/Data/" + nameof(GenerationData),
		order = 51)]
	public class GenerationData : ScriptableObject
	{
		[SerializeField] private Platform _startPlatformPrefab;
		[SerializeField] private Platform _endPlatformPrefab;

		[SerializeField] private List<Platform> _platformsPrefab;

		[field: SerializeField] public float OffsetBetweenPlatforms { get; private set; }
		[field: SerializeField] public int CountSpawnPlatform { get; private set; }

		public List<Platform> GetPlatforms()
		{
			var platforms = new List<Platform>(CountSpawnPlatform + 2) { _startPlatformPrefab };

			for (var i = 0; i < CountSpawnPlatform; i++)
			{
				Platform platformView = _platformsPrefab.Random();
				platforms.Add(platformView);
			}

			platforms.Add(_endPlatformPrefab);

			return platforms;
		}
	}
}