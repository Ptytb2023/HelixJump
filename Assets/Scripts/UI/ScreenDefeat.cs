using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ScreenDefeat : MonoBehaviour
	{
		[SerializeField] private Button _buttonReset;

		public event Action ClickReset;


		private void OnEnable() =>
			_buttonReset.onClick.AddListener(OnClickButton);

		private void OnDisable() =>
			_buttonReset.onClick.RemoveListener(OnClickButton);

		private void OnClickButton() =>
			ClickReset?.Invoke();
	}
}