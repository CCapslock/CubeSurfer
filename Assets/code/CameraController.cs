using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform CameraObjectTransform;

	private Vector3 _positionDifrence;
	private Vector3 _movementVector;
	private bool _needToFollowPlayer;
	private void Start()
	{
		_needToFollowPlayer = true;
		_positionDifrence = CameraObjectTransform.position - PlayerTransform.position;
		_movementVector = CameraObjectTransform.position;
	}
	private void FixedUpdate()
	{
		if (_needToFollowPlayer)
		{
			FollowPlayer();
		}
	}
	private void FollowPlayer()
	{
		_movementVector.x = PlayerTransform.position.x + _positionDifrence.x;
		_movementVector.z = PlayerTransform.position.z + _positionDifrence.z;
		CameraObjectTransform.position = _movementVector;
	}
}
