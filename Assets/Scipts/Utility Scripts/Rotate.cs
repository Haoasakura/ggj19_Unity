using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	public float m_speed;

	private Vector3 m_speedVector;

	private void Start() {
		m_speedVector = new Vector3(0f, m_speed, 0f);
	}
	void Update()
    {
		transform.Rotate(Vector3.up,m_speed*Time.deltaTime);
    }
}
