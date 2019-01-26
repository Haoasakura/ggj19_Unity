using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEvent : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name.Split('_')[0] + "_RoT");
        }
    }
}
