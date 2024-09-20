using UnityEngine;
using TMPro;  // Import Text Mesh Pro namespace

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Text Mesh Pro UI element to display the score
    private int score = 0;  // Current score

    void Start()
    {
        UpdateScoreDisplay();
    }

    // Method to increase score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }

    // Update the UI Text to display the current score
    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }
}
