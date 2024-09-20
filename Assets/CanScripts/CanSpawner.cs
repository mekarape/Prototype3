using UnityEngine;

public class CanSpawner : MonoBehaviour
{
    public GameObject canPrefab;  // The can prefab
    private GameObject currentCan;  // Reference to the current can in the scene

    private float screenMinX, screenMaxX;  // Screen boundaries for x-axis
    public float fixedYPosition = 2f;  // Fixed y position for the can
    public float boundaryMargin = 0.5f;  // Margin to prevent can from exiting the screen

    void Start()
    {
        // Get the screen boundaries based on the camera's viewport
        Vector3 screenBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
        Vector3 screenTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.transform.position.z));

        screenMinX = screenBottomLeft.x + boundaryMargin;  // Add margin to the left boundary
        screenMaxX = screenTopRight.x - boundaryMargin;  // Add margin to the right boundary

        // Spawn the first can at the start of the game
        SpawnCanAtRandomXPosition();
    }

    // Spawns a can at a random x position with a fixed y position
    public void SpawnCanAtRandomXPosition()
    {
        if (currentCan == null)
        {
            // Generate a random x position within the screen boundaries (with margin)
            float randomX = Random.Range(screenMinX, screenMaxX);

            // Set the can's position with the fixed y position and random x position
            Vector3 spawnPosition = new Vector3(randomX, fixedYPosition, 0);

            // Instantiate the can prefab at the random x position and fixed y position
            currentCan = Instantiate(canPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Called when the current can is destroyed
    public void OnCanDestroyed()
    {
        // Clear reference to the destroyed can
        currentCan = null;

        // Spawn a new can after a short delay
        Invoke(nameof(SpawnCanAtRandomXPosition), 0.5f);
    }
}
