using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ComedyData : ScriptableObject
{
	//private static ComedyData m_comedyDataInstance;
	//public static ComedyData Instance { get { if(!m_comedyDataInstance) m_comedyDataInstance = Resources.FindObjectsOfTypeAll<ComedyData>()[0]; if(!m_comedyDataInstance) m_comedyDataInstance = CreateInstance<ComedyData>(); return m_comedyDataInstance; } }

	private int m_numberOfDeaths;

	[SerializeField]
	List<Vector3> m_comedyPositions;

	public int NumberOfDeaths { get => m_numberOfDeaths; set => m_numberOfDeaths = value; }

	public void ResetValues() {
		m_comedyPositions.Clear();
	}

	public void ReloadComedy(ComedyManager comedyManager) {
		for(int i=0; i<m_comedyPositions.Count;i++) {
			comedyManager.AddRepetitionAtPosition(m_comedyPositions[i]);
		}
	}

	public void AddComedy(Vector3 position) {
		m_comedyPositions.Add(position);
		NumberOfDeaths++;
	}
}
