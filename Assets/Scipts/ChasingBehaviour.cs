using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingBehaviour : MonoBehaviour
{
	private Transform m_camera;

	private void Start() {
		m_camera = GameObject.FindGameObjectWithTag(Tags.MainCamera).transform;
	}
}
