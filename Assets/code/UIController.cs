using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject InGamePanel;

	public void ActivateInGamePanel()
	{
		StartPanel.SetActive(false);
		InGamePanel.SetActive(true);
	}
}
