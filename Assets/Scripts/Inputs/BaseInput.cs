using System;
using NewInputSystem;
using Zenject;

namespace Inputs
{
	public abstract class BaseInput : IInput, IDisposable
	{
		private bool _enable;
		protected MainInputMap InputMap { get; private set; }

		[Inject]
		protected BaseInput(MainInputMap inputMap)
		{
			InputMap = inputMap ?? throw new NullReferenceException();
			Enable = true;
			InputMap.Enable();
		}

		public bool Enable
		{
			get => _enable;
			set
			{
				if (value)
					TurnOn();
				else
					TurnOff();
				_enable = value;
			}
		}

		public void SetActive(bool value) => Enable = value;

		protected abstract void TurnOn();
		protected abstract void TurnOff();

		public void Dispose() => InputMap?.Dispose();
	}
}