using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public string myName;
    
    //Use this for initialization
    void Start()
    {
        Debug.Log("I am alive and my name is " + myName);
    }
}