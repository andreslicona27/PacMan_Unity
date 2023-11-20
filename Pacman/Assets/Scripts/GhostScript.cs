using System;
using UnityEngine;

/// <summary>
/// Class that control the movement of the ghost in the middle of the game.
/// </summary>
public class GhostScript : MonoBehaviour
{
    /// <summary>
    /// Referrences the main camara.
    /// </summary>
    private Camera mainCamera;

    /// <summary>
    /// Max Width of the main camara.
    /// </summary>
    private float maxWidth;

    /// <summary>
    /// Max Height of the main camara.
    /// </summary>
    private float maxHeight;

    /// <summary>
    /// Represents the direction of the ghost.
    /// </summary>
    private Vector2 direction;

    /// <summary>
    /// Initialize the variables in the class.
    /// </summary>
    public static float speed;

    /// <summary>
    /// Variable that stores the position of the camera or view on the screen.
    /// </summary>
    private Vector3 viewPos;

    /// <summary>
    /// Stores the amount of ghosts that are currently present in the game.
    /// </summary>
    public static int ghostNumber;

    /// <summary>
    /// References the ghost 4 that would appear during the game.
    /// </summary>
    public GameObject ghost4;

    /// <summary>
    /// References the ghost 5 that would appear during the game.
    /// </summary>
    public GameObject ghost5;

    /// <summary>
    /// References the ghost 6 that would appear during the game.
    /// </summary>
    public GameObject ghost6;

    /// <summary>
    /// References the ghost 7 that would appear during the game.
    /// </summary>
    public GameObject ghost7;


    /// <summary>
    /// Initialize the variables in the class.
    /// </summary>
    void Start()
    {
        try
        {
            if (Camera.main != null)
            {
                mainCamera = Camera.main;
                float cameraHeight = 2f * mainCamera.orthographicSize;
                maxWidth = cameraHeight * mainCamera.aspect;
                maxHeight = mainCamera.orthographicSize;
                direction = new Vector2(1, 1);
                speed = 4f;
                ghostNumber = 3;
            }
            else
            {
                Debug.LogWarning("Camera.main is null in KeepGhostBoundaries");
            }
        }
        catch (System.NullReferenceException nullRefEx)
        {
            Debug.LogError("Null reference error in Update: " + nullRefEx.Message);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    /// <summary>
    /// Updates the movement of the ghost.
    /// </summary>
    void Update()
    {
        try
        {
            if (GameLogic.gameRunning)
            {
                transform.Translate(speed * direction * Time.deltaTime);
            }
            KeepGhostBoundaries();

            if (ghostNumber <= 7)
            {
                AddGhost(ghostNumber);
            }
        }
        catch (System.NullReferenceException nullRefEx)
        {
            Debug.LogError("Null reference error in Update: " + nullRefEx.Message);
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError("Index Out of Range: " + e.ToString());
        }
        catch (InvalidOperationException e)
        {
            Debug.LogError("Invalid Operation: " + e.ToString());
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error in Update: " + ex.Message);
        }
    }

    /// <summary>
    /// In charge of maintaining the ghost inside the view camara.
    /// </summary>
    void KeepGhostBoundaries()
    {
        try
        {
            if (Camera.main != null)
            {
                viewPos = Camera.main.WorldToViewportPoint(transform.position);
                viewPos.x = Mathf.Clamp(viewPos.x, 0.05f, 0.95f);
                viewPos.y = Mathf.Clamp(viewPos.y, 0.05f, 0.95f);
                transform.position = Camera.main.ViewportToWorldPoint(viewPos);

                ChangedDirection();
            }
            else
            {
                Debug.LogWarning("Camera.main is null in KeepGhostBoundaries");
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    /// <summary>
    /// Change the direction in which the ghost is moving.
    /// </summary>
    public void ChangedDirection()
    {
        try
        {
            if (viewPos != null)
            {
                if (viewPos.x >= 0.95f || viewPos.x <= 0.05f)
                {
                    direction.x *= -1;
                }
                if (viewPos.y >= 0.95f || viewPos.y <= 0.05f)
                {
                    direction.y *= -1;
                }
            }
            else
            {
                Debug.LogWarning("viewPos is null in ChangedDirection");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error in ChangedDirection: " + ex.Message);
        }
    }

    /// <summary>
    /// Manage the collisions between ghosts and the walls. 
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            if (collision.gameObject.CompareTag("wall"))
            {
                ChangedDirection();
                Debug.Log("ghost should had change direction");
            }
        }
        catch (NullReferenceException nullRefEx)
        {
            Debug.LogError("Null reference error: " + nullRefEx.Message);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error in collision detection: " + ex.Message);
        }
    }

    /// <summary>
    /// Adds a new ghost to the game.
    /// </summary>
    /// <param name="ghosts"></param> Number of ghost that needs to be add.
    public void AddGhost(int ghosts)
    {
        try
        {
            if (ghosts > 3)
            {
                if (!ghost4.activeSelf)
                {
                    ghost4.SetActive(true);
                }
            }

            if (ghosts > 4)
            {
                if (!ghost5.activeSelf)
                {
                    ghost5.SetActive(true);
                }
            }

            if (ghosts > 5)
            {
                if (!ghost6.activeSelf)
                {
                    ghost6.SetActive(true);
                }
            }

            if (ghosts > 6)
            {
                if (!ghost7.activeSelf)
                {
                    ghost7.SetActive(true);
                }
            }
        }
        catch (System.NullReferenceException nullRefEx)
        {
            Debug.LogError("Null reference error in AddGhost: " + nullRefEx.Message);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error in AddGhost: " + ex.Message);
        }
    }
}