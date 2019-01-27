using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorPatform : MonoBehaviour
{
	public new string name="";
	public BoxCollider2D m_boxCollider2DTrigger;

	private void Start() {
		m_boxCollider2DTrigger.enabled = HubData.Instance.ShouldBeActive(name);
		if(m_boxCollider2DTrigger.enabled) {
			Color color = GetComponent<SpriteRenderer>().color;
			color.a = 1.0f;
			GetComponent<SpriteRenderer>().color=color;

		}
		else {
			Color color = GetComponent<SpriteRenderer>().color;
			color.a = 0.5f;
			GetComponent<SpriteRenderer>().color = color;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.CompareTag(Tags.Player)) {
			//HubData.Instance.PlayLevel(name);
			SceneManager.LoadScene(name);
		}

	}
}
