using UnityEngine;

public class InputController : MonoBehaviour
{
	//следит за пальцем на экране
	public Vector3 TouchPosition;
	public float JumpForceMaxPower;
	public float JumpForceMinPower;
	public float JumpForceGainSpeed;
	public bool InputStarted;

	private PlayerMovementController _movementController;
	private MainGameController _mainGameController;
	private bool _isGameStarted;
	[SerializeField]private float _jumpForce;
	private void Start()
	{
		_movementController = GetComponent<PlayerMovementController>();
		_mainGameController = GetComponent<MainGameController>();
		_isGameStarted = _mainGameController.IsGameStarted();
		TouchPosition = new Vector3(0, 0);
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (_isGameStarted)
			{
				InputStarted = true;
				TouchPosition = Input.mousePosition / 100f;
				TouchPosition.y = Input.mousePosition.y / 100f;
				TouchPosition.z = 0f;
			}
			else
			{
				_mainGameController.StartGame();
				_isGameStarted = true;
			}
		}
		else if (Input.GetMouseButtonUp(0) && InputStarted)
		{
			InputStarted = false;
			if (_jumpForce < JumpForceMinPower)
			{
				_jumpForce = JumpForceMinPower;
			}
			if (_jumpForce > JumpForceMaxPower)
			{
				_jumpForce = JumpForceMaxPower;
			}
			_movementController.MakeJump(_jumpForce);
			_jumpForce = 0f;
		}
	}
	private void FixedUpdate()
	{
		if (InputStarted)
		{
			CountJumpForce();
		}
	}
	private void CountJumpForce()
	{
		_jumpForce += JumpForceGainSpeed;
	}
}
