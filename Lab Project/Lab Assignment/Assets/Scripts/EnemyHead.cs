using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyHead : MonoBehaviour
{
    // Destroys enemy game object upon collision with player foot
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerFoot"))
        {
            Destroy(transform.parent.gameObject);
            
        }
    }
}
