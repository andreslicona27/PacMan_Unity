using JetBrains.Annotations;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private Camera mainCamera;
    private float maxWidth;
    private float maxHeight;
    public float speed = 5f;

    // Start is called before the first frame update
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
