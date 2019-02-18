using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubManager : MonoBehaviour
{
    void Start()
    {
		GameManager.DisableGravity(false);
		GameManager.instance.m_comedyData.ResetValues();
		//ComedyData.Instance.ResetValues();
	}
    void Update()
    {

    }
}
