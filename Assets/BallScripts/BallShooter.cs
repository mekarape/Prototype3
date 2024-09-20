using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;  // The ball prefab
    private GameObject currentBall;  // The current ball being controlled
    public float shootForce = 500f;  // Force to shoot the ball
    public float ballSpeed = 5f;  // Speed of side-to-side movement
    public float boundaryX = 8.89f;  // X-axis boundary for left-to-right movement
    public float speedIncrement = 1f;  // Amount to increase speed on collision

    private int direction = 1;  // 1 for right, -1 for left movement
    private Vector3 lastBallPosition;  // To store the last position of the ball
    private int lastDirection;  // To store the last direction of the ball (left or right)

    void Start()
    {
        // Spawn the first ball at the start of the game
        SpawnNewBall(transform.position, direction);
    }

    void Update()
    {
        // Move the current ball left to right
        if (currentBall != null)
        {
            MoveBallWithinBoundaries();
        }

        // Shoot the ball when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }
    }

    void MoveBallWithinBoundaries()
    {
        // Move the ball horizontally based on the direction
        currentBall.transform.Translate(Vector2.right * ballSpeed * direction * Time.deltaTime);

        // Check if the ball hits the boundary, reverse the direction if it does
        if (currentBall.transform.position.x >= boundaryX)
        {
            direction = -1;  // Move left
        }
        else if (currentBall.transform.position.x <= -boundaryX)
        {
            direction = 1;  // Move right
        }
    }

    void ShootBall()
    {
        // Apply gravity to the ball when it's shot downward
        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;  // Enable gravity so the ball falls
        rb.AddForce(Vector2.down * shootForce);  // Shoot the ball downward

        // Store the last position and direction of the ball
        lastBallPosition = currentBall.transform.position;
        lastDirection = direction;

        // Clear reference to the current ball, as it's now been shot
        currentBall = null;

        // Spawn a new ball at the last position and in the same direction after a small delay
        Invoke(nameof(SpawnNewBallAtLastPosition), 0.5f);
    }

    void SpawnNewBallAtLastPosition()
    {
        // Spawn a new ball at the last known position and with the same direction
        SpawnNewBall(lastBallPosition, lastDirection);
    }

    void SpawnNewBall(Vector3 position, int initialDirection)
    {
        // Create a new ball and set the movement direction to the previous ball's direction
        currentBall = Instantiate(ballPrefab, position, Quaternion.identity);
        direction = initialDirection;  // Use the stored direction from the previous ball

        // Reset speed and gravity for the new ball
        ballSpeed = 5f;  // Reset speed if needed, or keep increasing based on your logic
        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;  // Disable gravity for side-to-side movement
    }

    // Method to increase ball speed
    public void IncreaseBallSpeed()
    {
        ballSpeed += speedIncrement;  // Increase speed
    }
}
