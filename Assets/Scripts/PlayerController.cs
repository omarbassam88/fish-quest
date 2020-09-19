using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    public float jumpForce;
    public float upperBound;
    private bool canJump;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {

        // Detect User Input to add Force to Player
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            if (canJump && !gameManager.gameOver)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
            Debug.Log("Game Over");
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Ouchhh");
            playerRb.AddForce(Vector3.up * 1.5f * jumpForce, ForceMode.Impulse);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            gameManager.UpdateScore(1);
            Destroy(other.gameObject);
            Debug.Log("Just Collected an Item");
        }
    }


}
