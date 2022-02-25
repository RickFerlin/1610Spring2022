using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int day = 3;
        switch (day)
        {
            case 1:
                Console.WriteLine("Today is Saturday!");
                break;
            case 2:
                Console.WriteLine("Today is Sunday!");
                break;
            default:
                Console.WriteLine("Waiting for the weekend.");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
