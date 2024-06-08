using System.Collections;
using Inputs.Tower;
using UnityEngine;
using Zenject;

namespace Tower
{
	public class TowerView : MonoBehaviour
	{
		[SerializeField] private float _towerSpeedRotation;

		[Inject] private IInputTower _inputTower;

		private ObjectRotation _objectRotation;

		public void Start() =>
			_objectRotation = new ObjectRotation(_towerSpeedRotation, transform);

		private void OnEnable() =>
			_inputTower.PressedOrReleasesKey += OnPressedOrReleasesKey;

		private void OnPressedOrReleasesKey(bool isPressed)
		{
			if (isPressed)
				StartCoroutine(AddRotation());
		}

		private IEnumerator AddRotation()
		{
			while (_inputTower.IsPressed)
			{
				float deltaX = _inputTower.DeltaX;
				_objectRotation.AddRotation(deltaX);
				yield return new WaitForFixedUpdate();
			}
		}
	}
}