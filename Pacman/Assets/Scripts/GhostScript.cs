using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
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
    public Vector3 viewPos;

    /// <summary>
    /// Stores the amount of ghosts that are currently present in the game.
    /// </summary>
    public static int ghostNumber;

    public GameObject ghost4;


    /// <summary>
    /// Initialize the variables in the class.
    /// </summary>
    void Start()
    {
        try
        {
            mainCamera = Camera.main;
            float cameraHeight = 2f * mainCamera.orthographicSize;
            maxWidth = cameraHeight * mainCamera.aspect;
            maxHeight = mainCamera.orthographicSize;
            direction = new Vector2(1, 1);
            speed = 4f;
            ghostNumber = 3;

            //ghost4 = GetComponent<GameObject>();
            //ghost4.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    /// <summary>
    /// Updates the movement and colision of the ghost.
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
            //AddGhost(ghostNumber);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    /// <summary>
    /// In charge of maintaining the ghost inside the view camara.
    /// </summary>
    void KeepGhostBoundaries()
    {
        try
        {
            viewPos = Camera.main.WorldToViewportPoint(transform.position);
            viewPos.x = Mathf.Clamp(viewPos.x, 0.05f, 0.95f);
            viewPos.y = Mathf.Clamp(viewPos.y, 0.05f, 0.95f);
            transform.position = Camera.main.ViewportToWorldPoint(viewPos);

            ChangedDirection();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    /// <summary>
    /// Change the direction in which the ghost is moving.
    /// </summary>
    private void ChangedDirection()
    {
        try
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
        catch (Exception e)
        {
            Debug.Log(e.ToString());
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
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
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
            //if (!ghost4.activeSelf)
            //{
            //    ghost4.SetActive(true);
            //}
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}