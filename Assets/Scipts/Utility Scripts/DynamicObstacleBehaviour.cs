using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacleBehaviour : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.CompareTag(Tags.Player))
			collision.GetComponent<CharacterManager>().Die();
	}
}
