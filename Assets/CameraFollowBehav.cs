using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowBehav : MonoBehaviour
{

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
