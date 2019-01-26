using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Vector2 m_velocity;

	private void Update() {
		transform.Translate(m_velocity*Time.deltaTime);
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if(collision.CompareTag(Tags.Player)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
