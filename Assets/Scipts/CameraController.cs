using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
	public Vector2 m_velocity;
    public bool eventTriggered = false;

    private GameObject player;

    private void Start()
    {
        Debug.Log("Scene name: " + SceneManager.GetActiveScene().name.Split('_')[1]);

        if ("RoT".Equals(SceneManager.GetActiveScene().name.Split('_')[1]))
            eventTriggered = true;

        player = GameObject.FindGameObjectWithTag(Tags.Player);
    }

    private void Update() {
        if (!eventTriggered)
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        else
            transform.Translate(m_velocity*Time.deltaTime);
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if(collision.CompareTag(Tags.Player)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
