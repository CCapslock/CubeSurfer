using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
	private PlayerMovementController _playerMovementController;
	private UIController _uiController;
	private bool _gameStarted;

	private void Start()
	{
		_playerMovementController = GetComponent<PlayerMovementController>();
		_uiController = GetComponent<UIController>();
	}
	public bool IsGameStarted()
	{
		return _gameStarted;
	}
	public void StartGame()
	{
		_gameStarted = true;
		_playerMovementController.StartMovement(); 
		_uiController.ActivateInGamePanel();
	}
	public void RestartGame()
	{
		Invoke(nameof(LoadCurrentScene), 1.5f);
	}

	private void LoadCurrentScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
