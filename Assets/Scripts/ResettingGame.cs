using System.Collections;
using Ball;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResettingGame : MonoBehaviour
{
	[SerializeField] private ScreenDefeat _screenDefeat;
	[SerializeField] private BallView _ballView;
	[SerializeField] private float _delayTurnOn = 2f;

	private void OnEnable() =>
		_ballView.Dead += OnBallDead;

	private void OnDisable() =>
		_ballView.Dead -= OnBallDead;

	private void OnBallDead() =>
			StartCoroutine(TurnOnScreenDefeatByDelay());

	private void OnClickReset()
	{
		_screenDefeat.ClickReset -= OnClickReset;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private IEnumerator TurnOnScreenDefeatByDelay()
	{
		yield return new WaitForSeconds(_delayTurnOn);

		_screenDefeat.gameObject.SetActive(true);
		_screenDefeat.ClickReset += OnClickReset;
	}
}