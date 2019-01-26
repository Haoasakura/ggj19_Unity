using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	public float speed=10f;
	public float jumpForce = 5f;

	private bool m_canJump = true;
	private Rigidbody2D m_rigidbody2D;


    void Start()
    {
		m_rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
		float horizontal = Input.GetAxis("Horizontal");

		m_rigidbody2D.AddForce(new Vector2(horizontal, 0f) * speed * Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.Space) && m_canJump) {
			m_canJump = false;
			m_rigidbody2D.AddForce(Vector2.up*jumpForce);
		}


    }

	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.transform.CompareTag(Tags.Floor)) {
			m_canJump = false;
		}
	}
}
