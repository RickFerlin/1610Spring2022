using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoopsWithArrays : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
        for (int i = 0; i < cars.Length; i++) 
        {
            Console.WriteLine(cars[i]);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
