using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorPatform : MonoBehaviour
{
	public new string name="";

	private void Start() {
		//deactivate evenn when shece reloaded
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.CompareTag(Tags.Player))
			SceneManager.LoadScene(name);
	}
}
