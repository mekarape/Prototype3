using UnityEngine;

public class Can : MonoBehaviour
{
    private CanSpawner canSpawner;  // Reference to the CanSpawner script
    private ScoreManager scoreManager;  // Reference to the ScoreManager script
    private AudioSource audioSource;  // Reference to the AudioSource component

    void Start()
    {
        // Find the CanSpawner and ScoreManager in the scene
        canSpawner = FindObjectOfType<CanSpawner>();
        scoreManager = FindObjectOfType<ScoreManager>();

        // Get the AudioSource component attached to the can
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object the can collided with has the "Ball" tag
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Play the audio clip
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Notify the CanSpawner that this can has been destroyed
            canSpawner.OnCanDestroyed();

            // Add score
            scoreManager.AddScore(1);  // Add 1 point to the score

            // Destroy the ball
            Destroy(collision.gameObject);

            // Destroy the can (after a small delay to allow the sound to play)
            Destroy(gameObject, 0.5f);  // Delay destruction to let the audio play
        }
    }
}
