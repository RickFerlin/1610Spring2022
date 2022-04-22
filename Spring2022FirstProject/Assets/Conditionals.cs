using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditionals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int fifty = 50;
        int ten = 10;
        
        if (fifty > ten)
        {
            Debug.Log("Hello World");
        }
        else if (fifty == ten)
        {
            Debug.Log("Howdy World");
        }
        else
        {
            Debug.Log("Goodbye");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
