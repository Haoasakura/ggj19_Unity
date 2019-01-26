using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public GameObject m_creditsPanel;

	public void StartGame() {
		Cursor.visible = false;
		SceneManager.LoadScene("Hub_PL");
	}

	public void ExitGame() {
		Application.Quit();
	}

	public void ToggleCredits() {
		m_creditsPanel.SetActive(!m_creditsPanel.activeInHierarchy);
	}
}
