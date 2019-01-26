using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float timeToDestroy = 3f;

	public void Start() {
		Destroy(gameObject, timeToDestroy);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.CompareTag(Tags.Player)) {
			collision.GetComponent<CharacterManager>().Die();
			Destroy(gameObject);
		}

		if(collision.CompareTag(Tags.Floor)) {
			Destroy(gameObject);
		}
	}
}