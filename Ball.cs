using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private int collisionCount = 0;  // Counter for edge collisions

    void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        UnityEngine.Vector2 position = transform.position;
        UnityEngine.Vector2 scale = transform.localScale;

        position.x = 2;
        transform.position = position;

        scale.x = 0.25f;
        scale.y = 0.25f;
        transform.localScale = scale;

        Debug.Log("The first game object");

        // Generate a random direction
        float angle = Random.Range(0, Mathf.PI * 2);
        float magnitude = Random.Range(3f, 5f);

        // Convert to vector2 force
        UnityEngine.Vector2 force = new UnityEngine.Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * magnitude;

        // Apply force
        rb2d.AddForce(force, ForceMode2D.Impulse);
    }

    // Detect collisions
      void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Edge"))  // Check if collision is with the screen edge
        {
            collisionCount++;  // Increase the counter
            Debug.Log("Bang! Collision Count: " + collisionCount);

            if (collisionCount >= 20)  // Stop game & destroy ball after 20 collisions
            {
                Debug.Log("Ball object is destroyed after 20 collisions.");
                
                // Destroy the ball
                Destroy(gameObject);

                // Stop the game in Unity Editor
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
        }
    }
}

 