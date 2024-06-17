using System.Collections.Generic;
using Platforms;
using Tower;
using UnityEngine;

namespace Generation
{
	public class GenerationTower : MonoBehaviour
	{
		[SerializeField] private GenerationData _generationData;
		[SerializeField] private Transform _pillar;

		private const float AdditionScale = 3f;

		[ContextMenu(nameof(Generation))]
		public void Generation()
		{
			float height = SpawnPlatform();
			SpawnPillar(height);
		}

		public float SpawnPlatform()
		{
			float height = 0;
			List<Platform> platforms = _generationData.GetPlatforms();
			Platform lastPlatform = null;

			foreach (Platform platform in platforms)
			{
				float offsetBetweenPlatform = CalculateOffsetBetween(lastPlatform);
				height += offsetBetweenPlatform;
				Vector3 position = CalculateNewPosition(lastPlatform, offsetBetweenPlatform);

				lastPlatform = CreatePlatform(platform, position);
			}

			return height;
		}

		private void SpawnPillar(float height)
		{
			Vector3 originalScale = _pillar.localScale;
			float towerHeight = height / 2f;

			_pillar.localScale = new Vector3(originalScale.x, towerHeight, originalScale.z);
			_pillar.localPosition = Vector3.up * -towerHeight;
		}

		private Vector3 CalculateNewPosition(Platform lastPlatform, float offsetBetweenPlatform)
		{
			if (lastPlatform == null)
				return transform.position;

			Vector3 spawnPosition = lastPlatform.transform.position;
			Vector3 position = spawnPosition - new Vector3(0, offsetBetweenPlatform, 0);
			return position;
		}

		private float CalculateOffsetBetween(Platform lastPlatform)
		{
			if (lastPlatform == null)
				return 0;

			float lastScale = lastPlatform.transform.localScale.y;
			float offsetBetweenPlatform = _generationData.OffsetBetweenPlatforms + lastScale;
			return offsetBetweenPlatform;
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