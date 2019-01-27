using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardBehaviour : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag(Tags.Player))
        {
			collision.GetComponent<CharacterManager>().Die();

		}
    }
}
