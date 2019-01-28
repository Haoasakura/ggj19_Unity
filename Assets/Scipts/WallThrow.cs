using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallThrow : MonoBehaviour
{
	public float m_throwDelay=1.0f;
	public Sprite[] m_sprites=new Sprite[2];

	public GameObject m_projectile;

	private bool m_lastSprite;

	private BoxCollider2D m_boxCollider2D;

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
			projectile.GetComponent<SpriteRenderer>().sprite = m_lastSprite ? m_sprites[0] : m_sprites[1];
			m_lastSprite = !m_lastSprite;
			yield return waitTime;
		}
	}
}
