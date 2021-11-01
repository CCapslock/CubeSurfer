using UnityEngine;
using System.Collections.Generic;

public class PlayerMovementController : MonoBehaviour
{
	public Transform PlayerTransform;
	public GameObject SingleCube;
	public float PlayerSpeed;
	public float JumpSpeed;
	public float MinJumpSpeed;


	private MainGameController _mainGameController;
	private List<GameObject> _allCubes;
	private Vector3 _movementVector;
	private bool _canMove;
	private float _jumpMaxHeight;
	private float _jumpMinHeight;
	[SerializeField] private int _cubeAmount = 1;
	private bool _jumpUp;
	private bool _jumpDown;
	private void Start()
	{
		_mainGameController = GetComponent<MainGameController>();
		_allCubes = new List<GameObject>();
		_movementVector = new Vector3();
		_jumpMinHeight = PlayerTransform.position.y;
		_allCubes.Add(PlayerTransform.gameObject);
	}
	private void FixedUpdate()
	{
		if (_canMove)
		{
			MoveForward();
		}
	}
	private void MoveForward()
	{
		_movementVector = PlayerTransform.position;
		_movementVector.x += PlayerSpeed;
		if (_jumpUp)
		{
			_movementVector.y += JumpSpeed * (_jumpMaxHeight - PlayerTransform.position.y) + MinJumpSpeed;
			if (_movementVector.y >= _jumpMaxHeight)
			{
				_jumpUp = false;
				_jumpDown = true;
			}
		}
		if (_jumpDown)
		{
			_movementVector.y -= JumpSpeed * (_jumpMaxHeight - PlayerTransform.position.y) + MinJumpSpeed;
			if (_movementVector.y <= _jumpMinHeight +0.1f)
			{
				_jumpUp = false;
				_jumpDown = false;
				_movementVector.y = _jumpMinHeight;
			}
		}
		PlayerTransform.position = _movementVector;
	}
	public void StartMovement()
	{
		_canMove = true;
	}
	public void StopMovement()
	{
		_canMove = false;
	}
	public void MakeJump(float jumpForce)
	{
		if (!_jumpDown && !_jumpUp)
		{
			_jumpUp = true;
			_jumpMaxHeight = PlayerTransform.position.y + jumpForce;
		}
	}
	public void AddCube()
	{
		_cubeAmount++;
		_allCubes.Add(Instantiate(SingleCube, new Vector3(PlayerTransform.position.x, PlayerTransform.position.y + _cubeAmount - 1f, 0), Quaternion.identity, PlayerTransform));
	}
	public void LoseCube()
	{
		if (_cubeAmount > 1)
		{
			_cubeAmount--;
			_allCubes[_cubeAmount].transform.parent = null;

			_movementVector = _allCubes[_cubeAmount].transform.position;
			_movementVector.y = PlayerTransform.position.y;
			_allCubes[_cubeAmount].transform.position = _movementVector;

			_movementVector = PlayerTransform.position;
			_movementVector.y += 1f;
			PlayerTransform.position = _movementVector;
			_allCubes.RemoveAt(_cubeAmount);
			_jumpDown = false;
			_jumpUp = false;
			MakeJump(0);
		}
		else
		{
			StopMovement();
			_mainGameController.RestartGame();
		}
	}
}
