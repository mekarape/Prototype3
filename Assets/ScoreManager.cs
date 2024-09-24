using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Text Mesh Pro UI element to display the score
    private int score = 0;  // Current score
    private int maxScore = 20;  // The maximum score to win the game
    private PlayerController playerController;  // Reference to the PlayerController

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();  // Find the PlayerController in the scene
        UpdateScoreDisplay();
    }

    // Method to increase score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreDisplay();

        // Check if the score has reached the maxScore (30 points)
        if (score >= maxScore)
        {
            playerController.GameWon();  // Trigger the game won logic
        }
    }

    // Update the UI Text to display the current score in "0/30" format
    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score + "/" + maxScore;
    }
}

