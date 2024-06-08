using System;

namespace Inputs.Tower
{
	public interface IInputTower : IInput
	{
		public bool IsPressed { get; }
		public float DeltaX { get; }
		public event Action<bool> PressedOrReleasesKey;
	}
}