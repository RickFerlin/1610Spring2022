using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    
    private float jumpForce = 25;
    public float speed = 10.0f;
    private Rigidbody playerRb;
    public float gravForce = 9.81f;
    public float maxXSpeed;
    public float maxYSpeed;

    public bool isOnGround = true;
    public bool isOnCeiling = true;
    public bool isOnLWall = true;
    public bool isOnRWall = true;
    private bool isOnCrate = false;

    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip gravSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        //Gets rigidbody and sets initial bool for gravity direction to allow jumping
        playerRb = GetComponent<Rigidbody>();
        isOnGround = true;
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

        //Sets bool to see if player is on crate
        if (collision.gameObject.CompareTag("Crate"))
        {
            isOnCrate = true;
        }
    }

    void MovePlayer()
    {
        //player movement variables
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");



        //jump mechanics for each gravitational pull
        //also plays jump sound
        if (Input.GetKeyDown(KeyCode.Space) && Physics.gravity.y == -gravForce && (isOnGround || isOnCrate))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            isOnCrate = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Physics.gravity.y == gravForce && (isOnCeiling || isOnCrate))
        {
            playerRb.AddForce(Vector3.down * jumpForce, ForceMode.Impulse);
            isOnCeiling = false;
            isOnCrate = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Physics.gravity.x == -gravForce && (isOnLWall || isOnCrate))
        {
            playerRb.AddForce(Vector3.right * jumpForce, ForceMode.Impulse);
            isOnLWall = false;
            isOnCrate = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Physics.gravity.x == gravForce && (isOnRWall || isOnCrate))
        {
            playerRb.AddForce(Vector3.left * jumpForce, ForceMode.Impulse);
            isOnRWall = false;
            isOnCrate = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
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

        //Movement speed cap
        if (Mathf.Abs(playerRb.velocity.x) > speed)
        {
            speedCap();
        }

        if (Math.Abs(playerRb.velocity.y) > speed)
        {
            speedCap();
        }

        //player rotation. When key is pressed, the player will rotate.
        //Sound effect will also play
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 newRotation = new Vector3(0, 0, -90);
            transform.eulerAngles = newRotation;
            playerAudio.PlayOneShot(gravSound, 1.0f);
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;
            playerAudio.PlayOneShot(gravSound, 1.0f);
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 newRotation = new Vector3(0, 0, 90);
            transform.eulerAngles = newRotation;
            playerAudio.PlayOneShot(gravSound, 1.0f);
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 newRotation = new Vector3(0, 0, 180);
            transform.eulerAngles = newRotation;
            playerAudio.PlayOneShot(gravSound, 1.0f);
        }
        
        //Turns player model to face movement direction. Needs specification on
        //each due to gravitational shift in order to avoid character turning
        //while jumping.
        if ((playerRb.velocity.x < 0) && (Physics.gravity.y == -gravForce))
        {
           transform.localScale = new Vector3(-1, 1, 1);
        } else if (playerRb.velocity.x > 0 && (Physics.gravity.y == -gravForce))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if ((playerRb.velocity.x < 0) && (Physics.gravity.y == gravForce))
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (playerRb.velocity.x > 0 && (Physics.gravity.y == gravForce))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if ((playerRb.velocity.y > 0) && (Physics.gravity.x == -gravForce))
        {
           transform.localScale = new Vector3(-1, 1, 1);
        } else if (playerRb.velocity.y < 0 && (Physics.gravity.x == -gravForce))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if ((playerRb.velocity.y > 0) && (Physics.gravity.x == gravForce))
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (playerRb.velocity.y < 0 && (Physics.gravity.x == gravForce))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    
    //Game over script.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerAudio.PlayOneShot(deathSound, 1.0f);
            Time.timeScale = 0;
            Debug.Log("Game Over");
            gameManager.isGameActive = false;
            gameManager.gameOverScreen.SetActive(true);
        }
    }
    
    //Sets max movement speed so AddForce doesn't accelerate for infinity
    private void speedCap()
    {
        maxXSpeed = Mathf.Min(Mathf.Abs(playerRb.velocity.x), speed) * Mathf.Sign(playerRb.velocity.x);
        maxYSpeed = Mathf.Min(Mathf.Abs(playerRb.velocity.y), speed) * Mathf.Sign(playerRb.velocity.y);

        playerRb.velocity = new Vector3(maxXSpeed, maxYSpeed, 0);
    }
}