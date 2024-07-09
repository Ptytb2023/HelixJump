using Ball;
using Generation;
using Inputs.Tower;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SettingPannel : MonoBehaviour
{
	[SerializeField] private GenerationDataSo _generationDataSo;
	[SerializeField] private GenerationTower _generation;
	[SerializeField] private BallView _ballView;

	[SerializeField] private Slider _slider;
	[SerializeField] private Button _startButton;

	[Inject] private IInputTower _inputTower;


	private void OnDisable()
	{
		_startButton.onClick.RemoveListener(StartGame);
	}

	private void OnEnable()
	{
		_startButton.onClick.AddListener(StartGame);
	}

	private void StartGame()
	{
		_generation.gameObject.SetActive(true);
		_ballView.gameObject.SetActive(true);

		_inputTower.SetMultiplayDeltaX(_slider.value);
		gameObject.SetActive(false);
	}


}