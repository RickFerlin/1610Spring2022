using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float dogTimer = 0;
    private float dogInterval = 1.0f;

    // Update is called once per frame
    void Update()
    {
        //set the dog timer to count time
        dogTimer = dogTimer + Time.deltaTime;
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dogTimer >= dogInterval)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                dogTimer = 0;
            }
            
        }
    }
}
