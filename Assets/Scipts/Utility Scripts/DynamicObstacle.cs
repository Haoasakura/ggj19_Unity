using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObstacle : MonoBehaviour
{
	[SerializeField]
	Transform m_platform;
	[SerializeField]
	Transform m_startTransform;
	[SerializeField]
	Transform m_endTransform;
	[SerializeField]
	float m_speed;

	Vector3 m_direction;
	Transform m_destination;

    void Start()
    {
		SetDestination(m_startTransform);
    }


    void Update()
    {
		m_platform.Translate(m_direction * m_speed * Time.fixedDeltaTime);
		if(Vector2.Distance(m_platform.position, m_destination.position) < m_speed * Time.fixedDeltaTime)
			SetDestination(m_destination==m_startTransform?m_endTransform:m_startTransform);
    }

	void SetDestination(Transform destination) {
		m_destination = destination;
		m_direction = (destination.position - m_platform.position).normalized;
	}

	private void OnDrawGizmos() {

		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(m_startTransform.position, m_platform.localScale);

		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(m_endTransform.position, m_platform.localScale);
	}
}
