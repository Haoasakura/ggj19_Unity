using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	[SerializeField]
	private float m_speed=10f;
	[SerializeField]
	private float m_jumpForce = 5f;
	[SerializeField]
	private bool m_canJump = true;
	[SerializeField]
	private bool m_canDoubleJump = true;
	[SerializeField]
	private bool m_canJumpOnAir = true;

	private Rigidbody2D m_rigidbody2D;

    void Start()
    {
		m_rigidbody2D = GetComponent<Rigidbody2D>();

	}


	private void Update() {
		float horizontal = Input.GetAxis("Horizontal");

		transform.Translate(new Vector3(horizontal, 0f, 0f) * m_speed * Time.deltaTime);

	}


	void FixedUpdate()
    {

		if(Input.GetKeyDown(KeyCode.Space) && (m_canJump || (!m_canJump && m_canJumpOnAir))) {
			if(m_canJump)
				m_canJump = false;
			else {
				m_canJumpOnAir = false;

			}
			m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, 0f);
			m_rigidbody2D.AddForce(Vector2.up*m_jumpForce,ForceMode2D.Impulse);
		}

    }

	/*private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.transform.CompareTag(Tags.Floor)) {
			m_canJump = true;
			m_canJumpOnAir = true;
		}
	}*/

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.transform.CompareTag(Tags.Floor)) {
			m_canJump = true;
			m_canJumpOnAir = true;
		}
	}
}
