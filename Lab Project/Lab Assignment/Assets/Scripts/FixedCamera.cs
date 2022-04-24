using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class FixedCamera : MonoBehaviour
{
    //Script fixes the camera to the player, while also ensuring
    //that it does not rotate when the player rotates due to
    //gravitational change.
    
    private Quaternion my_rotation;

    private Transform playerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        my_rotation = this.transform.rotation;

        playerPos = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -9);
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -9);
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -9);
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -9);
        }
    }

    void LateUpdate()
    {
        this.transform.rotation = my_rotation;
    }
}