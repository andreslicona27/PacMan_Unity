using UnityEngine;

/// <summary>
/// Class that manage the coin´s properties.
/// </summary>
public class CoinScript : MonoBehaviour
{
    /// <summary>
    /// References the main camara in the game.
    /// </summary>
    private Camera mainCamera;

    /// <summary>
    /// Initialize the variables in the class
    /// </summary>
    void Start()
    {
        try
        {
            mainCamera = Camera.main;
            if (mainCamera != null)
            {
                RandomPosition();
            }
            else
            {
                Debug.LogError("No main camera found.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error in Start(): " + e.Message);
            Debug.LogException(e);
        }
    }

    /// <summary>
    /// Generates a random position to locate the coin in the main camera
    /// </summary>
    public void RandomPosition()
    {
        try
        {
            if (mainCamera != null)
            {
                float cameraHeight = 2f * mainCamera.orthographicSize * 0.9f;
                float cameraWidth = cameraHeight * mainCamera.aspect * 0.9f;

                float randomX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
                float randomY = Random.Range(-cameraHeight / 2f, cameraHeight / 2f);

                Vector3 randomPosition = new Vector3(randomX, randomY, 0f);
                transform.position = randomPosition;
            }
            else
            {
                Debug.LogError("No main camera found.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error in RandomPosition(): " + e.Message);
            Debug.LogException(e);
        }
    }
}
