using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Food : Projectile
{
	public float m_timeToHit;
	private float m_angle=45f;
	private Transform m_player;
	private Rigidbody2D m_rigidbody2D;

	private void Awake() {
		m_player=GameObject.FindGameObjectWithTag(Tags.Player).transform;
		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	public new void Start() {
		base.Start();
		Launch();
	}

	private void Launch() {

		Vector2 pos = transform.position;
		Vector2 target = m_player.position;


		float dist = Vector2.Distance(pos, target);


		float Vi = Mathf.Sqrt(dist * -Physics.gravity.y / (Mathf.Sin(Mathf.Deg2Rad * m_angle * 2)));
		float Vy, Vz;

		Vy = Vi * Mathf.Sin(Mathf.Deg2Rad * m_angle);
		Vz = Vi * Mathf.Cos(Mathf.Deg2Rad * m_angle);


		Vector2 localVelocity = new Vector2(Vy, Vz);


		Vector3 globalVelocity = transform.TransformVector(localVelocity);

		//m_rigidbody2D.velocity = globalVelocity;
		m_rigidbody2D.AddForce(globalVelocity*Random.Range(1.1f,1.5f),ForceMode2D.Impulse);

	}
}
