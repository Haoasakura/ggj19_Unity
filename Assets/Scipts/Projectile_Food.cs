using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Food : Projectile
{

	public Rigidbody2D ball;
	private Transform m_player;

	public float m_h = 0f;
	public float m_gravity = -18f;

	public bool debugPath;

	private void Awake() {
		m_player=GameObject.FindGameObjectWithTag(Tags.Player).transform;
	}

	public new void Start() {
		base.Start();
		ball = GetComponent<Rigidbody2D>();
		ball.gravityScale = 0f;
		Launch();
	}

	void Update() {
		if(debugPath) {
			DrawPath();
		}
	}

	void Launch() {

		ball.gravityScale = 1f;
		Vector3 checkedVelocity = CalculateLaunchData().initialVelocity;
		if(float.IsNaN(checkedVelocity.x) || float.IsNaN(checkedVelocity.y))
			checkedVelocity = new Vector3(0f, 0f, 0f);
		ball.velocity = checkedVelocity * Random.Range(0.95f, 1.1f);
	}

	LaunchData CalculateLaunchData() {
		float displacementY = m_player.position.y - ball.position.y;
		Vector2 displacementXZ = new Vector2(m_player.position.x - ball.position.x, 0);
		float time = Mathf.Sqrt(-2 * m_h / m_gravity) + Mathf.Sqrt(2 * (displacementY - m_h) / m_gravity);
		Vector2 velocityY = Vector2.up * Mathf.Sqrt(-2 * m_gravity * m_h);
		Vector2 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(m_gravity), time);
	}

	void DrawPath() {
		LaunchData launchData = CalculateLaunchData();
		Vector2 previousDrawPoint = ball.position;

		int resolution = 30;
		for(int i = 1; i <= resolution; i++) {
			float simulationTime = i / (float)resolution * launchData.timeToTarget;
			Vector2 displacement = launchData.initialVelocity * simulationTime + Vector2.up * m_gravity * simulationTime * simulationTime / 2f;
			Vector2 drawPoint = ball.position + displacement;
			Debug.DrawLine(previousDrawPoint, drawPoint, Color.green);
			previousDrawPoint = drawPoint;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.CompareTag(Tags.Player)) {
			collision.GetComponent<CharacterManager>().EatFood();
			Destroy(gameObject);
		}

		if(collision.CompareTag(Tags.Floor)) {
			Destroy(gameObject);
		}
	}

	struct LaunchData
	{
		public readonly Vector2 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData(Vector2 initialVelocity, float timeToTarget) {
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;
		}

	}

}
