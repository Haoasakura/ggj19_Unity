using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComedyManager : MonoBehaviour
{

	public GameObject m_canvas;
	public GameObject m_repetitionText;

	private BoxCollider2D m_boxCollider2D;
	private Bounds m_bounds;

	private void Start() {
		m_boxCollider2D = GetComponent<BoxCollider2D>();
		m_bounds= m_boxCollider2D.bounds;
		StartCoroutine("Rep");
		GameManager.instance.m_comedyData.ReloadComedy(this);
		//ComedyData.Instance.ReloadComedy(this);
	}

	IEnumerator Rep() {
		while(true) {
			//AddRepetition();
			yield return new WaitForSeconds(5f);
		}
	}
	public void AddRepetition(Vector3 _position) {
		int numberOfDeads = GameManager.instance.m_comedyData.NumberOfDeaths;
		float x = Random.Range(_position.x-5f, _position.x+5f);
		float y = Random.Range(m_bounds.min.y, m_bounds.max.y);
		Vector3 finalPosition = new Vector3(x, y, 0f);

		GameObject tmp = Instantiate(m_repetitionText, finalPosition, Quaternion.identity);
		tmp.transform.SetParent(m_canvas.transform,true);
		tmp.transform.localScale = new Vector3(0.7f,0.7f,1f);
		GameManager.instance.m_comedyData.AddComedy(tmp.transform.position);

	}



	public void AddRepetitionAtPosition(Vector3 _position) {
		GameObject tmp = Instantiate(m_repetitionText, _position, Quaternion.identity);
		tmp.transform.SetParent(m_canvas.transform, true);
		tmp.transform.localScale = new Vector3(0.7f, 0.7f, 1f);


	}
}
