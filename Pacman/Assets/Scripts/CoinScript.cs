using JetBrains.Annotations;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that manage the coin´s properties.
/// </summary>
public class CoinScript : MonoBehaviour
{
    private Camera mainCamera;
    private float maxWidth;
    private float maxHeight;
    public float speed = 5f;

    /// <summary>
    /// Initialize the variables in the class
    /// </summary>
    void Start()
    {
        try
        {
            mainCamera = Camera.main;
            float cameraHeight = 2f * mainCamera.orthographicSize;
            maxWidth = cameraHeight * mainCamera.aspect;
            maxHeight = mainCamera.orthographicSize;

            RandomPosition();
        }
        catch (System.Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
        }
    }

    /// <summary>
    /// Generates a random position for the coin between the camara limits
    /// </summary>
    public void RandomPosition()
    {
        try
        {
            float cameraHeight = 2f * mainCamera.orthographicSize;
            float cameraWidth = cameraHeight * mainCamera.aspect;

            float randomX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
            float randomY = Random.Range(-cameraHeight / 2f, cameraHeight / 2f);

            Vector3 randomPosition = new Vector3(randomX, randomY, 0f);
            transform.position = randomPosition;
        }
        catch (System.Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
        }
    }
}
