using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public float gravForce = 9.81f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //change gravity in all directions. Heck yeah.
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Physics.gravity = new Vector3(-gravForce, 0, 0);
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Physics.gravity = new Vector3(0, -gravForce, 0);
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Physics.gravity = new Vector3(gravForce, 0, 0);
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Physics.gravity = new Vector3(0, gravForce, 0);
        }
    }
}
