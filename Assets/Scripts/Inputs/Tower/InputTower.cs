using System;
using NewInputSystem;
using UnityEngine.InputSystem;

namespace Inputs.Tower
{
	public sealed class InputTower : BaseInput, IInputTower
	{
		private float _multiplayDeltaX = 1f;

		public InputTower(MainInputMap inputMap) : base(inputMap)
		{
		}

		public event Action<bool> PressedOrReleasesKey;

		public void SetMultiplayDeltaX(float multiplay)
		{
			_multiplayDeltaX = multiplay;
		}

		public bool IsPressed { get; private set; }
		public float DeltaX => InputMap.Tower.DeltaX.ReadValue<float>() * _multiplayDeltaX;

		protected override void TurnOn()
		{
			InputMap.Tower.FirstPress.started += OnFirstPress;
			InputMap.Tower.FirstPress.canceled += OnFirstPress;
		}

		protected override void TurnOff()
		{
			InputMap.Tower.FirstPress.started -= OnFirstPress;
			InputMap.Tower.FirstPress.canceled -= OnFirstPress;
		}

		private void OnFirstPress(InputAction.CallbackContext callbackContext)
		{
			IsPressed = !callbackContext.canceled;
			PressedOrReleasesKey?.Invoke(IsPressed);
		}
	}
}