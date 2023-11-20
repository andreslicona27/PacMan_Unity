using UnityEngine;

/// <summary>
/// Class that manage all the characteristics of the maze, like creating it, destroying the wall and showing them in the game
/// </summary>
public class MazeScript : MonoBehaviour
{
    /// <summary>
    /// Array that handles all the shapes.
    /// </summary>
    public GameObject[] shapes;

    /// <summary>
    /// Reference the new shape that is going to be added.
    /// </summary>
    GameObject newShape;

    /// <summary>
    /// Image resource to add a texture to the shapes 
    /// </summary>
    public Sprite sprite;

    /// <summary>
    /// Function that adds the physics components to every square 
    /// </summary>
    public void AddPhysics()
    {
        try
        {
            Rigidbody2D rigidbody = newShape.AddComponent<Rigidbody2D>();
            rigidbody.gravityScale = 0;
            rigidbody.bodyType = RigidbodyType2D.Static;

            // COLLIDER
            BoxCollider2D rectangleCollider = newShape.AddComponent<BoxCollider2D>();
            rectangleCollider.size = new Vector2(0.75f, 0.5f);
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("Null Reference in CreateShape: " + e.ToString());
        }
        catch (UnityException e)
        {
            Debug.LogError("Unity Exception in CreateShape: " + e.ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Unknown Exception in CreateShape: " + e.ToString());
        }
    }

    /// <summary>
    /// Fucntion adds the properties that every rectangle needs
    /// </summary>
    public void AddProperties()
    {
        try
        {
            // SPRITE
            sprite = Resources.Load<Sprite>("Sprites/wall");
            SpriteRenderer spriteRenderer = newShape.AddComponent<SpriteRenderer>();
            spriteRenderer.drawMode = SpriteDrawMode.Sliced;
            spriteRenderer.sprite = sprite;
            spriteRenderer.size = new Vector2(0.75f, 0.75f);
            spriteRenderer.color = new Color(0.5f, 0.5f, 1f);

            // ROTATION We do it with this formula for it to be only horizontal or vertical
            float randomRotation = Random.Range(0, 2) * 90f;
            newShape.transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);

            newShape.transform.localScale = new Vector3(1.5f, 0.75f, 1f);
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("Null Reference in CreateShape: " + e.ToString());
        }
        catch (UnityException e)
        {
            Debug.LogError("Unity Exception in CreateShape: " + e.ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Unknown Exception in CreateShape: " + e.ToString());
        }
    }

    /// <summary>
    /// Creates a new rectangle to create the walls of the maze
    /// </summary>
    private void CreateWall()
    {
        try
        {
            newShape = new GameObject("Wall");
            newShape.tag = "wall";
            AddProperties();
            AddPhysics();
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("Null Reference in CreateShape: " + e.ToString());
        }
        catch (UnityException e)
        {
            Debug.LogError("Unity Exception in CreateShape: " + e.ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Unknown Exception in CreateShape: " + e.ToString());
        }
    }

    /// <summary>
    /// Generates all the shapes that area  going to being shown in the game and destroys the old ones when the maze change.
    /// </summary>
    public void GenerateMaze()
    {
        try
        {
            DestroyMaze();
            int numberOfShapes = 20;
            for (int i = 0; i < numberOfShapes; i++)
            {
                CreateWall();

                Vector3 randomPosition = GetRandomPosition();
                Vector3 viewportPosition = Camera.main.WorldToViewportPoint(randomPosition);

                if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
                {
                    newShape.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
                }
                else
                {
                    newShape.transform.position = randomPosition;
                }
            }
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("Null Reference in GenerateShapes: " + e.ToString());
        }
        catch (UnityException e)
        {
            Debug.LogError("Unity Exception in GenerateShapes: " + e.ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Unknown Exception in GenerateShapes: " + e.ToString());
        }
    }

    /// <summary>
    /// Destroys all the shapes in the array for them to be regenerate again.
    /// </summary>
    private void DestroyMaze()
    {
        try
        {
            GameObject[] existingShapes = GameObject.FindGameObjectsWithTag("wall");
            foreach (GameObject shape in existingShapes)
            {
                Destroy(shape);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Exception occurred in DestroyExistingShapes: " + e.ToString());
        }
    }

    /// <summary>
    /// Generate a random position for each of the shapes taking in consideration that it has to have a minumin distance between the rest of the shapes 
    /// </summary>
    /// <returns>A random postion</returns>
    private Vector3 GetRandomPosition()
    {
        try
        {
            float cameraHeight = 2f * Camera.main.orthographicSize * 0.9f;
            float cameraWidth = cameraHeight * Camera.main.aspect * 0.9f;

            float minDistance = 0.75f; // Minumun distance between walls
            Vector3 randomPosition;

            do
            {
                float randomX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
                float randomY = Random.Range(-cameraHeight / 2f, cameraHeight / 2f);

                randomPosition = new Vector3(randomX, randomY, 0f);

                Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPosition, minDistance);
                bool separated = true;

                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("wall"))
                    {
                        // Calaculates the cistance between the positions
                        float distance = Vector3.Distance(collider.transform.position, randomPosition);

                        if (distance < minDistance)
                        {
                            separated = false;
                            break;
                        }
                    }
                }
                if (separated)
                {
                    break;
                }
            }
            while (true);

            return randomPosition;
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("Null Reference in GetRandomPosition: " + e.ToString());
            return Vector3.zero;
        }
        catch(System.OutOfMemoryException e)
        {
            Debug.LogError("Out of Memory in GetRandomPosition: " + e.ToString());
            return Vector3.zero;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Exception occurred in GetRandomPosition: " + e.ToString());
            return Vector3.zero;
        }
    }
}