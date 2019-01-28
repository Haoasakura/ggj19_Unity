using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingBehaviour : MonoBehaviour
{
	private CameraController m_cameraController;
	private float m_displacement;
	public bool m_rightDirection = true;

	private void Start() {
		m_cameraController = GameObject.FindGameObjectWithTag(Tags.MainCamera).GetComponent<CameraController>();
		if(m_rightDirection)
			m_displacement = m_cameraController.GetComponent<BoxCollider2D>().bounds.center.x - m_cameraController.GetComponent<BoxCollider2D>().bounds.extents.x;
		else
			m_displacement = m_cameraController.GetComponent<BoxCollider2D>().bounds.center.x + m_cameraController.GetComponent<BoxCollider2D>().bounds.extents.x;

		transform.position = new Vector3(m_displacement, transform.position.y, transform.position.z);
	}
	private void LateUpdate() {
		if(m_cameraController.m_chasing)
			transform.Translate(m_cameraController.m_velocity * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		/*if(collision.CompareTag(Tags.Player)) {
			collision.GetComponent<CharacterManager>().Die();
		}*/
	}
}
