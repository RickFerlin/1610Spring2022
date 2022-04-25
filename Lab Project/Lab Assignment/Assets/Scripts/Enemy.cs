using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 7;
    public Vector3[] positions;
    private int index;
    private Rigidbody enemyRb;

    void Update()
    
    //Allows enemy to move between set locations determined by the array
    {
        enemyRb = GetComponent<Rigidbody>();
        transform.position = Vector3.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }
}
