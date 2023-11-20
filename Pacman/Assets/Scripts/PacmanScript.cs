using System;
using System.IO;
using UnityEngine;

/// <summary>
/// Class that manage the movement of the player in the game.
/// </summary>
public class PacmanScript : MonoBehaviour
{
    /// <summary>
    /// References the sprite of pacman when its closed.
    /// </summary>
    private Sprite spriteClosed;

    /// <summary>
    /// References the sprite of pacman when is opened.
    /// </summary>
    private Sprite spriteOpen;

    /// <summary>
    /// References the amount of speed that pacman would have during the game.
    /// </summary>
    public float speed = 5.0f;

    /// <summary>
    /// Represents the speed at which the sprite changes.
    /// </summary>
    private float spriteChangeSpeed = 0.1f;

    /// <summary>
    /// References the sprite render component.
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// References the current direction of the movement.
    /// </summary>
    private Vector2 direction = Vector2.zero;

    /// <summary>
    /// References to the Rigidbody2D of the component.
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// Represents the time of the last sprite change.
    /// </summary>
    private float lastSpriteChangeTime = 0.0f;

    /// <summary>
    /// Initialize the variables in the class.
    /// </summary>
    void Start()
    {
        try
        {
            spriteClosed = Resources.Load<Sprite>("Sprites/pacmanClosed");
            spriteOpen = Resources.Load<Sprite>("Sprites/pacmanOpen");

            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            }
            spriteRenderer.sprite = spriteOpen;
            rb = GetComponent<Rigidbody2D>();
        }
        catch (MissingComponentException e)
        {
            Debug.LogError("Missing Component: " + e.ToString());
        }
        catch (ArgumentNullException e)
        {
            Debug.LogError("Argument Null: " + e.ToString());
        }
        catch (IOException e)
        {
            Debug.LogError("IO Exception: " + e.ToString());
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    /// <summary>
    /// Updates que pacaman movement across the game.
    /// </summary>
    void Update()
    {
        try
        {
            if (GameLogic.gameRunning)
            {
                MovePacman();
                ChangePacmanSprite();
                ChangePacmanDirection();
                KeepPacmanBoundaries();
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Null Reference: " + e.ToString());
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError("Index Out of Range: " + e.ToString());
        }
        catch (InvalidOperationException e)
        {
            Debug.LogError("Invalid Operation: " + e.ToString());
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    /// <summary>
    /// Move pacman according to the direction the player choose with the arrows keys.
    /// </summary>
    private void MovePacman()
    {
        try
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            if (horizontalInput > 0)
            {
                direction = Vector2.right;
            }
            else if (horizontalInput < 0)
            {
                direction = Vector2.left;
            }
            else if (verticalInput > 0)
            {
                direction = Vector2.up;
            }
            else if (verticalInput < 0)
            {
                direction = Vector2.down;
            }
            rb.velocity = direction * speed;
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Null Reference: " + e.ToString());
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError("Index Out of Range: " + e.ToString());
        }
        catch (InvalidOperationException e)
        {
            Debug.LogError("Invalid Operation: " + e.ToString());
        }
        catch (Exception e)
        {
            Debug.LogError("Unknown Exception: " + e.ToString());
        }
    }

    /// <summary>
    /// Changes the pacman spirte depending on the direction of the movement of the player.
    /// </summary>
    private void ChangePacmanSprite()
    {
        try
        {
            if (Time.time - lastSpriteChangeTime >= spriteChangeSpeed && direction != Vector2.zero)
            {
                if (spriteRenderer.sprite == spriteClosed)
                {
                    spriteRenderer.sprite = spriteOpen;
                }
                else
                {
                    spriteRenderer.sprite = spriteClosed;
                }
                lastSpriteChangeTime = Time.time;
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Null Reference: " + e.ToString());
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    /// <summary>
    /// Change the direction of the pacman image depending in the direction of the movement.
    /// </summary>
    private void ChangePacmanDirection()
    {
        try
        {
            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Null Reference: " + e.ToString());
        }
        catch (ArgumentException e)
        {
            Debug.LogError("Argument Reference: " + e.ToString());
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    /// <summary>
    /// Keeps pacman inside the camara view.
    /// </summary>
    private void KeepPacmanBoundaries()
    {
        try
        {
            Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            viewPos.x = Mathf.Clamp(viewPos.x, 0.05f, 0.95f);
            viewPos.y = Mathf.Clamp(viewPos.y, 0.05f, 0.95f);
            transform.position = Camera.main.ViewportToWorldPoint(viewPos);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Null Reference: " + e.ToString());
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }
}