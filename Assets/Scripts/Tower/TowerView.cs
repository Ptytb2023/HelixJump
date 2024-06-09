using System;
using System.Collections;
using Inputs.Tower;
using UnityEngine;
using Zenject;

namespace Tower
{
	public class TowerView : MonoBehaviour
	{
		[SerializeField] private float _towerSpeedRotation;

		private IInputTower _inputTower;
		private TowerRotation _towerRotation;
		
		public float TowerSpeedRotation => _towerSpeedRotation;
		
		[Inject]
		private void Construct(IInputTower inputTower) => 
			_inputTower = inputTower;

		private void Start() => 
			_towerRotation = new TowerRotation(_towerSpeedRotation, transform);

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
				_towerRotation.AddRotation(deltaX);
				yield return new WaitForFixedUpdate();
			}
		}
	}
}