using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
		DontDestroyOnLoad(gameObject);
		HubData.Instance.ResetValues();
	}

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
    }
}
