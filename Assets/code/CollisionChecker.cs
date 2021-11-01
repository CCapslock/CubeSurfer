using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
	private PlayerMovementController _playerMovementController;
	private MainGameController _mainGameController;

	private void Start()
	{
		_playerMovementController = FindObjectOfType<PlayerMovementController>();
		_mainGameController = FindObjectOfType<MainGameController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(TagManager.GetTag(TagType.CollectableCube)))
		{
			Destroy(other.gameObject);
			_playerMovementController.AddCube();
		}
		if (other.CompareTag(TagManager.GetTag(TagType.WinTrigger)))
		{
			_mainGameController.RestartGame();
			_playerMovementController.StopMovement();
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag(TagManager.GetTag(TagType.Obstacle)))
		{
			collision.gameObject.tag = TagManager.GetTag(TagType.Untagged);
			_playerMovementController.LoseCube();
		}
	}
}
