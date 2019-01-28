using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallThrow : MonoBehaviour
{
	public float m_throwDelay=1.0f;

	public GameObject m_projectile;
	BoxCollider2D m_boxCollider2D;

	private void Awake() {
		m_boxCollider2D = GetComponent<BoxCollider2D>();
	}

	void Start()
    {
		StartCoroutine("ThrowFood");
	}

	public IEnumerator ThrowFood() {

		WaitForSeconds waitTime = new WaitForSeconds(m_throwDelay);
		while(true) {

			GameObject projectile= Instantiate(m_projectile, m_boxCollider2D.bounds.center,Quaternion.identity);

			yield return waitTime;
		}
	}
}
