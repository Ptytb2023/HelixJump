using System;
using System.Collections;
using Inputs.Tower;
using UnityEngine;
using Zenject;

public class TestingInput : MonoBehaviour
{
	[Inject] private IInputTower _inputTower;
	private bool _isPressed;
	private Coroutine _corutine;

	private void OnEnable()
	{
		_inputTower.PressedOrReleasesKey += OnPressedOrReleasesKey;
	}

	private void OnDisable()
	{
		_inputTower.PressedOrReleasesKey -= OnPressedOrReleasesKey;
	}


	private void OnPressedOrReleasesKey(bool isPressed)
	{
		_isPressed = isPressed;
		
		if (isPressed)
			_corutine = StartCoroutine(ShowDelatX());
		else
		{
			if (_corutine is not null)
				StopCoroutine(_corutine);
		}
	}

	private IEnumerator ShowDelatX()
	{
		while (_isPressed)
		{
			Debug.Log(_inputTower.DeltaX);
			yield return null;
		}
	}
}