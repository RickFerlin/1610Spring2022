using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float jumpForce = 25;
    private float speed = 10.0f;
    private Rigidbody playerRb;
    public float gravForce = 9.81f;

    public bool isOnGround = true;
    public bool isOnCeiling = true;
    public bool isOnLWall = true;
    public bool isOnRWall = true;

    // Start is called before the first frame update
    void Start()
    {
        //Gets rigidbody and sets initial bool for gravity direction to allow jumping
        playerRb = GetComponent<Rigidbody>();
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Collisions set to detect when player is on a surface based on gravity direction
        if (collision.gameObject.CompareTag("Ground") && Physics.gravity.y == -gravForce)
        {
            isOnGround = true;
            isOnCeiling = false;
            isOnLWall = false;
            isOnRWall = false;
        }
        else if (collision.gameObject.CompareTag("Ceiling") && Physics.gravity.y == gravForce)
        {
            isOnGround = false;
            isOnCeiling = true;
            isOnLWall = false;
            isOnRWall = false;
        }
        else if (collision.gameObject.CompareTag("LWall") && Physics.gravity.x == -gravForce)
        {
            isOnGround = false;
            isOnCeiling = false;
            isOnLWall = true;
            isOnRWall = false;
        }
        else if (collision.gameObject.CompareTag("RWall") && Physics.gravity.x == gravForce)
        {
            isOnGround = false;
            isOnCeiling = false;
            isOnLWall = false;
            isOnRWall = true;
        }
    }

    void MovePlayer()
    {
        //player movement variables
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");



        //jump mechanics for each gravitational pull
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isOnCeiling)
        {
            playerRb.AddForce(Vector3.down * jumpForce, ForceMode.Impulse);
            isOnCeiling = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isOnLWall)
        {
            playerRb.AddForce(Vector3.right * jumpForce, ForceMode.Impulse);
            isOnLWall = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isOnRWall)
        {
            playerRb.AddForce(Vector3.left * jumpForce, ForceMode.Impulse);
            isOnRWall = false;
        }


        //player movement. Player is restricted from moving in certain directions based on gravity direction.
        if (Physics.gravity.y == -gravForce)
        {
            playerRb.AddForce(Vector3.right * speed * horizontalInput);
        }
        else if (Physics.gravity.y == gravForce)
        {
            playerRb.AddForce(Vector3.right * speed * horizontalInput);
        }
        else if (Physics.gravity.x == -gravForce)
        {
            playerRb.AddForce(Vector3.up * speed * verticalInput);
        }
        else if (Physics.gravity.x == gravForce)
        {
            playerRb.AddForce(Vector3.up * speed * verticalInput);
        }

        //player rotation. When key is pressed, the player will rotate.

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 newRotation = new Vector3(0, 0, -90);
            transform.eulerAngles = newRotation;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 newRotation = new Vector3(0, 0, 90);
            transform.eulerAngles = newRotation;
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 newRotation = new Vector3(0, 0, 180);
            transform.eulerAngles = newRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }
}