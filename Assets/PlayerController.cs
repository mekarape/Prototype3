using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject gameOverScene;
    public GameObject startGameText;
    public GameObject victoryText;  // Victory text to show when the game is won

    private bool gameIsOver = false;
    private bool gameIsStarted = false;

    // Static variable to check if we are restarting the game
    public static bool isRestarting = false;

    void Start()
    {
        if (isRestarting)
        {
            // If we are restarting, skip the start screen and directly start the game
            StartGame();
        }
        else
        {
            // If it's a fresh start, show the start game screen
            Time.timeScale = 0;
            startGameText.SetActive(true);
            gameOverScene.SetActive(false);
            victoryText.SetActive(false);  // Ensure victory text is hidden at the start
        }
    }

    void Update()
    {
        if (gameIsOver && Input.GetKeyDown(KeyCode.Return))
        {
            Restart();
        }

        if (!gameIsStarted && Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startGameText.SetActive(false);
        gameIsStarted = true;
        isRestarting = false;  // Reset the restarting flag when the game starts
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScene.SetActive(true);
        gameIsOver = true;
    }

    // Method to handle the game winning logic
    public void GameWon()
    {
        Time.timeScale = 0;  // Pause the game
        victoryText.SetActive(true);  // Show victory text
        gameIsOver = true;  // Mark game as over
    }

    public void Restart()
    {
        Time.timeScale = 1;
        isRestarting = true;  // Set the flag to true before reloading the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



