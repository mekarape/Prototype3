using UnityEngine;

public class Can : MonoBehaviour
{
    private CanSpawner canSpawner;  // Reference to the CanSpawner script
    private ScoreManager scoreManager;  // Reference to the ScoreManager script

    void Start()
    {
        // Find the CanSpawner and ScoreManager in the scene
        canSpawner = FindObjectOfType<CanSpawner>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object the can collided with has the "Ball" tag
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Notify the CanSpawner that this can has been destroyed
            canSpawner.OnCanDestroyed();

            // Destroy the ball
            Destroy(collision.gameObject);

            // Add score
            //scoreManager.AddScore(1);  // Add 1 point to the score

            // Destroy the can
            Destroy(gameObject);
        }
    }
}
