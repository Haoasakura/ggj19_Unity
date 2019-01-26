using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallThrow : MonoBehaviour
{
	public float m_throwDelay=1.0f;

	public GameObject m_projectile;


    void Start()
    {
		StartCoroutine("ThrowFood");
    }

	public IEnumerator ThrowFood() {

		WaitForSeconds waitTime = new WaitForSeconds(m_throwDelay);
		while(true) {

			Instantiate(m_projectile,transform.position,Quaternion.identity);

			yield return waitTime;
		}
	}
}
