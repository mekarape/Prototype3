using UnityEngine;

public class BallSpeedController : MonoBehaviour
{
    public float speedIncrement = 1f;  // Amount to increase speed
    private BallShooter ballShooter;  // Reference to the BallShooter script
    private ScoreManager scoreManager;  // Reference to the ScoreManager script

    void Start()
    {
        // Find the BallShooter and ScoreManager in the scene
        ballShooter = FindObjectOfType<BallShooter>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collided with is tagged as "Can"
        if (collision.gameObject.CompareTag("Can"))
        {
            // Increase the ball speed in the BallShooter
            ballShooter.IncreaseBallSpeed(speedIncrement);

            // Add score when the ball collides with the can
            scoreManager.AddScore(1);  // You can change 1 to however many points you want to add

            // Optionally, destroy the ball after collision
            Destroy(gameObject);
        }
    }
}
