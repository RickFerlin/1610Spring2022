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
            Console.WriteLine("Hello World");
        }
        else if (fifty == ten)
        {
            Console.WriteLine("Howdy World");
        }
        else
        {
            Console.WriteLine("Goodbye");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
