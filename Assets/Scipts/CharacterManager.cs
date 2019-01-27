using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{

	public bool m_resizeLevel = false;
	public float m_MinsizeAllowed = 0.01f;
	public float m_sizeDecrementAmount = 0.01f;
	public float m_sizeIncrementAmount = 0.1f;
	public float m_moveDecrementAmount = 0.01f;

	private CharacterMovement m_characterMovement;

    void Start()
    {
		m_characterMovement = GetComponent<CharacterMovement>();

	}

    void Update()
    {
		if (m_resizeLevel) {
			transform.localScale-= new Vector3(m_sizeDecrementAmount, m_sizeDecrementAmount, 0f);
			if(m_characterMovement.m_speed < m_characterMovement.m_initialSpeed)
				m_characterMovement.m_speed += m_moveDecrementAmount/10;
			if(transform.localScale.x <= m_MinsizeAllowed) {
				Die();
			}

		}

    }

	public void EatFood() {
		transform.localScale += new Vector3(m_sizeIncrementAmount, m_sizeIncrementAmount, 0f);
		m_characterMovement.m_speed -= m_moveDecrementAmount;
		m_characterMovement.m_jumpForce -= m_moveDecrementAmount;

	}

	public void Die() {
        if(GameManager.instance!=null)
		    GameManager.instance.m_comedyData.NumberOfDeaths++;
		GameObject comedyManager = GameObject.FindGameObjectWithTag(Tags.ComedyManager);
		if(comedyManager != null)
			comedyManager.GetComponent<ComedyManager>().AddRepetition(transform.position);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
