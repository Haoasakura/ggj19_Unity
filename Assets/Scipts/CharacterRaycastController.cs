using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRaycastController : MonoBehaviour
{
	private BoxCollider2D m_boxCollider2D;
	[SerializeField]
	private LayerMask m_layerMask;


    // Start is called before the first frame update
    void Start()
    {
		m_boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public bool CanMoveInDirection(bool rightDirection) {

		if(rightDirection) {
			RaycastHit2D raycastHitUR = Physics2D.Raycast(m_boxCollider2D.bounds.max - new Vector3(0f, 0.0017f, 0f), Vector2.right, 0.017f, m_layerMask);
			RaycastHit2D raycastHitBR = Physics2D.Raycast(m_boxCollider2D.bounds.max - new Vector3(0f, m_boxCollider2D.bounds.extents.y * 2, 0f) + new Vector3(0f, 0.0017f, 0f), Vector2.right, 0.017f, m_layerMask);
			if((raycastHitUR.transform != null && raycastHitUR.transform.CompareTag(Tags.Floor)) || (raycastHitBR.transform != null && raycastHitBR.transform.CompareTag(Tags.Floor))) {
				/*if(raycastHitUR.transform != null)
					Debug.Log(raycastHitUR.transform.name);
				if(raycastHitBR.transform != null)
					Debug.Log(raycastHitBR.transform.name);*/
				return false;
			}
		}
		else{
			RaycastHit2D raycastHitUL = Physics2D.Raycast(m_boxCollider2D.bounds.min - new Vector3(0f, 0.0017f, 0f), Vector2.left, 0.017f, m_layerMask);
			RaycastHit2D raycastHitBL = Physics2D.Raycast(m_boxCollider2D.bounds.min + new Vector3(0f, m_boxCollider2D.bounds.extents.y * 2, 0f) + new Vector3(0f, 0.0017f, 0f), Vector2.left, 0.017f, m_layerMask);
			if((raycastHitUL.transform != null && raycastHitUL.transform.CompareTag(Tags.Floor)) || (raycastHitBL.transform != null && raycastHitBL.transform.CompareTag(Tags.Floor))) {
				/*if(raycastHitUL.transform != null)
					Debug.Log(raycastHitUL.transform.name);
				if(raycastHitBL.transform != null)
					Debug.Log(raycastHitBL.transform.name);*/
				return false;
			}
		}

		return true;
	}

	public bool CanJump() {

			RaycastHit2D raycastHitDR = Physics2D.Raycast(m_boxCollider2D.bounds.max - new Vector3(0f, m_boxCollider2D.bounds.extents.y * 2, 0f) - new Vector3(0.0017f, 0f, 0f), Vector2.down, 0.02f, m_layerMask);
			RaycastHit2D raycastHitDL = Physics2D.Raycast(m_boxCollider2D.bounds.min + new Vector3(0.002f, 0f, 0f), Vector2.down, 0.02f, m_layerMask);
			if((raycastHitDR.transform != null && raycastHitDR.transform.CompareTag(Tags.Floor)) || (raycastHitDL.transform != null && raycastHitDL.transform.CompareTag(Tags.Floor))) {
				return true;
			}

		return false;
	}

	private void OnDrawGizmos() {
		if(m_boxCollider2D != null) {
			Gizmos.DrawLine(m_boxCollider2D.bounds.max - new Vector3(0f, 0.002f, 0f), m_boxCollider2D.bounds.max + new Vector3(0.015f, 0f, 0f) - new Vector3(0f, 0.0017f, 0f));
			Gizmos.DrawLine(m_boxCollider2D.bounds.max - new Vector3(0f, m_boxCollider2D.bounds.extents.y * 2, 0f) + new Vector3(0f, 0.0017f, 0f), m_boxCollider2D.bounds.max - new Vector3(0f, m_boxCollider2D.bounds.extents.y * 2, 0f) + new Vector3(0.015f, 0f, 0f) + new Vector3(0f, 0.002f, 0f));

			Gizmos.DrawLine(m_boxCollider2D.bounds.min - new Vector3(0f, 0.002f, 0f), m_boxCollider2D.bounds.min - new Vector3(0.015f, 0f, 0f) - new Vector3(0f, 0.0017f, 0f));
			Gizmos.DrawLine(m_boxCollider2D.bounds.min + new Vector3(0f, m_boxCollider2D.bounds.extents.y * 2, 0f) + new Vector3(0f, 0.0017f, 0f), m_boxCollider2D.bounds.min + new Vector3(0f, m_boxCollider2D.bounds.extents.y * 2, 0f) - new Vector3(0.015f, 0f, 0f) + new Vector3(0f, 0.002f, 0f));

			Gizmos.DrawLine(m_boxCollider2D.bounds.max - new Vector3(0f, m_boxCollider2D.bounds.extents.y * 2, 0f) - new Vector3(0.0017f, 0f, 0f), m_boxCollider2D.bounds.max - new Vector3(0f, m_boxCollider2D.bounds.extents.y * 2, 0f) - new Vector3(0.0017f, 0f, 0f) - new Vector3(0f, 0.017f, 0f));

			Gizmos.DrawLine(m_boxCollider2D.bounds.min + new Vector3(0.002f, 0f, 0f), m_boxCollider2D.bounds.min + new Vector3(0.002f, 0f, 0f) - new Vector3(0f, 0.017f, 0f));
		}

	}
}
