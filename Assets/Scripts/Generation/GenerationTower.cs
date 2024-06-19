using System;
using System.Collections.Generic;
using Platforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Generation
{
	public class GenerationTower : MonoBehaviour
	{
		[SerializeField] private GenerationData _generationData;
		[SerializeField] private Transform _pillar;

		private readonly List<Platform> _platforms = new List<Platform>();

		private const float MultiplyHeightTower = 3f;

		private void Start()
			=> Generation();

		[ContextMenu(nameof(Generation))]
		public void Generation()
		{
			SpawnPlatform();
			float distance = GetDistanceOnFirstToLastPlatrom();
			FitTowerHeight(distance);
		}

		private float GetDistanceOnFirstToLastPlatrom()
		{
			if (_platforms.Count < 2)
				throw new ArgumentOutOfRangeException($"{_platforms.Count} It can't be less than 2");

			Vector3 firstPlatform = _platforms[0].transform.position;
			Vector3 lastPlatform = _platforms[^1].transform.position;
			return (firstPlatform - lastPlatform).magnitude;
		}

		private void SpawnPlatform()
		{
			List<Platform> spawnPlatforms = _generationData.GetPlatforms();
			Platform lastPlatform = null;

			foreach (Platform platform in spawnPlatforms)
			{
				float offsetBetweenPlatform = GetOffsetBetweenOrDefault(lastPlatform);
				Vector3 position = GetNewPositionOrDefault(lastPlatform, offsetBetweenPlatform);

				lastPlatform = CreatePlatform(platform, position);
				_platforms.Add(lastPlatform);
			}
		}

		private void FitTowerHeight(float height)
		{
			Vector3 originalScale = _pillar.localScale;
			float towerHeight = height / 2f;
			Vector3 multiplyHeightTower = _generationData.OffsetBetweenPlatforms * MultiplyHeightTower * Vector3.up;

			_pillar.localScale = new Vector3(originalScale.x, towerHeight, originalScale.z) + multiplyHeightTower;

			_pillar.localPosition = Vector3.up * -(towerHeight);
		}

		private Vector3 GetNewPositionOrDefault(Platform lastPlatform, float offsetBetweenPlatform)
		{
			if (lastPlatform == null)
				return transform.position;

			Vector3 spawnPosition = lastPlatform.transform.position;
			Vector3 position = spawnPosition - new Vector3(0, offsetBetweenPlatform, 0);
			return position;
		}

		private float GetOffsetBetweenOrDefault(Platform lastPlatform)
		{
			float defaultOffset = _generationData.OffsetBetweenPlatforms;

			if (lastPlatform == null)
				return defaultOffset;

			float scaleY = lastPlatform.transform.localScale.y;
			float offset = defaultOffset + scaleY;
			return offset;
		}


		private Platform CreatePlatform(Platform platform, Vector3 position)
		{
			Vector3 randomRotation = new Vector3(0, Random.Range(0, 360), 0);

			Platform newPlatform = Instantiate(platform, position, Quaternion.Euler(randomRotation));

			newPlatform.transform.parent = transform;
			newPlatform.gameObject.SetActive(true);

			return newPlatform;
		}
	}
}