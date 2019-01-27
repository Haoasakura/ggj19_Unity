using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
		DontDestroyOnLoad(gameObject);
		HubData.Instance.ResetValues();
	}

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
    }

	public static void DisableGravity(bool value) {
		Transform player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
		if(player!=null) {
			if(value) {
				player.GetComponent<Rigidbody2D>().gravityScale = 0f;
				player.GetComponent<CharacterMovement>().m_followTheCamera=true;
				player.GetComponent<CharacterMovement>().m_canEverJump = false;

			}
			else {
				player.GetComponent<Rigidbody2D>().gravityScale = player.GetComponent<CharacterMovement>().m_initialGravityScale;
				player.GetComponent<CharacterMovement>().m_followTheCamera = false;
				player.GetComponent<CharacterMovement>().m_canEverJump = true;

			}
		}
	}
}
