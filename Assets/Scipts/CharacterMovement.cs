using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

	public float m_speed=10f;
	public float m_jumpForce = 5f;
	[SerializeField]
	private bool m_canJump = true;
	[SerializeField]
	private bool m_canDoubleJump = true;
	[SerializeField]
	private bool m_canJumpOnAir = true;

	[HideInInspector]
	public float m_initialSpeed;
	[HideInInspector]
	public float m_initialJumpForce;

	private bool m_rightDirection = true;

	private Rigidbody2D m_rigidbody2D;
	private CharacterRaycastController m_raycastController;
	private SpriteRenderer m_spriteRenderer;

    void Start()
    {
		m_initialSpeed = m_speed;
		m_initialJumpForce = m_jumpForce;
		m_rigidbody2D = GetComponent<Rigidbody2D>();
		m_raycastController = GetComponent<CharacterRaycastController>();
		m_spriteRenderer = GetComponent<SpriteRenderer>();
	}


	private void Update() {
		float horizontal = Input.GetAxis("Horizontal");

		if(horizontal >= 0) {
			m_rightDirection = true;
			m_spriteRenderer.flipX=false;
		}
		else {
			m_rightDirection = false;
			m_spriteRenderer.flipX = true;
		}

		if(m_raycastController.CanMoveInDirection(m_rightDirection)) {
			transform.Translate(new Vector3(horizontal, 0f, 0f) * m_speed * Time.deltaTime);

		}

		m_canJump = m_raycastController.CanJump();
		if(m_canJump)
			m_canJumpOnAir = true;

		if(Input.GetKeyDown(KeyCode.Space) && (/*m_raycastController.CanJump()*/ m_canJump || (m_canDoubleJump && m_canJumpOnAir))) {
			/*if(m_canJump)
				m_canJump = false;
			else {
				m_canJumpOnAir = false;

			}*/
			if(!m_canJump/*m_raycastController.CanJump()*/ && m_canJumpOnAir)
				m_canJumpOnAir = false;

			m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, 0f);
			m_rigidbody2D.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
		}

	}

	/*private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.transform.CompareTag(Tags.Floor)) {
			m_canJump = true;
			m_canJumpOnAir = true;
		}
	}*/

	private void OnTriggerEnter2D(Collider2D collision) {
		/*if(collision.transform.CompareTag(Tags.Floor)) {
			m_canJump = true;
			m_canJumpOnAir = true;
		}*/
	}
}
