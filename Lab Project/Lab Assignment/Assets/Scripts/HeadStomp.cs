using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadStomp : MonoBehaviour
{
    //Sets the collision for the player to be able to jump on the enemy's head to defeat them.
    
    private Rigidbody playerRb;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, 0f);
            playerRb.AddForce(Vector3.up * 300f);
        }
    }
}
