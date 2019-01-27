using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;

	public HubData m_hubData;
	public ComedyData m_comedyData;

	void Awake()
    {

		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		m_hubData.ResetValues();
		//m_comedyData.ResetValues();
		//HubData.Instance.ResetValues();
		//ComedyData.Instance.ResetValues();
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
