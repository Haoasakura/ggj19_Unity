using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class HubData : ScriptableObject
{

	//private static HubData m_hubDataInstance;
	//public static HubData Instance { get { if(!m_hubDataInstance) m_hubDataInstance = Resources.FindObjectsOfTypeAll<HubData>()[0]; if(!m_hubDataInstance) m_hubDataInstance = CreateInstance<HubData>(); return m_hubDataInstance; } }

	[SerializeField]
	List<SelectorData> m_levelPlatform;

	public void ResetValues() {
		for(int i = 0; i < m_levelPlatform.Count; i++)
				m_levelPlatform[i].value = true;
	}

	public bool ShouldBeActive(string key) {
		foreach(SelectorData selectorData in m_levelPlatform)
			if(selectorData.levelName.Equals(key))
				return selectorData.value;
		return false;
	}

	public void PlayLevel(string key) {
		for(int i = 0; i < m_levelPlatform.Count; i++)
			if(m_levelPlatform[i].levelName.Equals(key))
				m_levelPlatform[i].value = false;

	}

}
