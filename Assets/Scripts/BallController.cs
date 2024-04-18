using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class BallController : MonoBehaviour
{
    #region VARIABLES
    private Rigidbody2D rb;
    
    public Vector2 startingVelocity = new Vector2(5f, -5f);

    public GameManager gameManager;

    public float initialSpeed = 5f;
    public float speedUp = 1.1f;
    #endregion

    #region METHODS
    public void ResetBall() 
    {
        transform.position = Vector3.zero;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = startingVelocity;
        StartRandomMovement();
        
    }

    void StartRandomMovement() 
    {
        // Set a random direction
        Vector2[] diagonalDirections =
        {new Vector2(1, 1).normalized, 
         new Vector2(1.5f, 1).normalized, 
         new Vector2(1, 1.5f).normalized, 
         new Vector2(-1, 1).normalized,
         new Vector2(-1.5f, 1).normalized,
         new Vector2(-1, 1.5f).normalized,
         new Vector2(1, -1).normalized,
         new Vector2(1.5f, -1).normalized,
         new Vector2(1, -1.5f).normalized,        
         new Vector2(-1, -1).normalized,
         new Vector2(-1.5f, -1).normalized,
         new Vector2(-1, -1.5f).normalized
        };
        
        Vector2 randomDirection = diagonalDirections[UnityEngine.Random.Range(0, diagonalDirections.Length)];
        rb.velocity = randomDirection.normalized * initialSpeed;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) 
        {
            Vector2 newVelocity = rb.velocity;

            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
        }

        if (collision.gameObject.CompareTag("Player 2") || collision.gameObject.CompareTag("Player")) 
        {

            rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y);
            rb.velocity *= speedUp;
        }

        if (collision.gameObject.CompareTag("Player Point"))
        {
            gameManager.PlayerScore();
            ResetBall();
        }

        else if (collision.gameObject.CompareTag("Player 2 Point")) 
        {
            gameManager.Player2Score();
            ResetBall();
        }

    }
    
    #endregion
}
