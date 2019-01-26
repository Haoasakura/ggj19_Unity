using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesShooter : MonoBehaviour
{
	[SerializeField]
	private float m_throwDelay = 1.0f;
	[SerializeField]
	private Vector2 m_direction;
	[SerializeField]
	private float m_force;
	[SerializeField]
	private GameObject m_projectile;


	void Start() {
		StartCoroutine("ShootObstacle");
	}

	public IEnumerator ShootObstacle() {

		WaitForSeconds waitTime = new WaitForSeconds(m_throwDelay);
		while(true) {

			GameObject projectile = Instantiate(m_projectile, transform.position, Quaternion.identity);
			projectile.GetComponent<Rigidbody2D>().AddForce(m_direction * m_force, ForceMode2D.Impulse);

			yield return waitTime;
		}
	}
}
