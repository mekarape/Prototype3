using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime = 30f;  // Set to 30 seconds
    private float currentTime;
    public TextMeshProUGUI timerText;  // Use TextMeshProUGUI for TMP text

    private PlayerController playerController;  // Reference to PlayerController

    void Start()
    {
        currentTime = totalTime;
        playerController = FindObjectOfType<PlayerController>();  // Find the PlayerController in the scene
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            // Update the timer display
            timerText.text = currentTime.ToString("0.0") + " seconds";  // Shows one decimal place

            // Wait for one frame
            yield return null;

            // Reduce the current time by the time passed in this frame
            currentTime -= Time.deltaTime;
        }

        // Ensure timer reaches zero
        currentTime = 0;
        timerText.text = "0.0 seconds";

        // Timer finished
        OnTimerEnd();
    }

    void OnTimerEnd()
    {
        // Call the GameOver method from PlayerController when the timer ends
        if (playerController != null)
        {
            playerController.GameOver();
        }
        else
        {
            Debug.LogError("PlayerController not found!");
        }
    }
}

