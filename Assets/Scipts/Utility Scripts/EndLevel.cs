﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.CompareTag(Tags.Player)) {
			if(SceneManager.GetActiveScene().buildIndex< SceneManager.sceneCountInBuildSettings) {
				SceneManager.LoadScene("Hub_PL");
			}

		}
	}
}
