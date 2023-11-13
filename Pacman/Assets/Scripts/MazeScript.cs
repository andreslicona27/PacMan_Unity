using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScript : MonoBehaviour
{
    public GameObject[] shapes;
    GameObject newShape;
    public Color shapeColor; 

    void Start()
    {
        shapeColor = new Color(0.0f, 0.0f, 0.5f);
    }

    private void CreateShape()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                newShape = new GameObject("Square");
                newShape.AddComponent<SpriteRenderer>();
                var squareCollider = newShape.AddComponent<BoxCollider2D>();
                //var squareRigidbody = newShape.AddComponent<Rigidbody2D>();
                //squareRigidbody.gravityScale = 0;
                break;
            case 1:
                newShape = new GameObject("Circle");
                newShape.AddComponent<SpriteRenderer>();
                var circleCollider = newShape.AddComponent<CircleCollider2D>();
                //var circleRigidbody = newShape.AddComponent<Rigidbody2D>();
                //circleRigidbody.gravityScale = 0;
                break;
            case 2:
                newShape = new GameObject("Triangle");
                newShape.AddComponent<SpriteRenderer>();
                var triangleCollider = newShape.AddComponent<PolygonCollider2D>();
                //var triangleRigidbody = newShape.AddComponent<Rigidbody2D>();
                //triangleRigidbody.gravityScale = 0;
                break;
            default:
                newShape = new GameObject("Square");
                newShape.AddComponent<SpriteRenderer>();
                var rectangleCollider = newShape.AddComponent<BoxCollider2D>();
                //var rectangleRigidbody = newShape.AddComponent<Rigidbody2D>();
                //rectangleRigidbody.gravityScale = 0;
                break;
        }
    }

    public void GenerateShapes()
    {
        DestroyExistingShapes();
        int numberOfShapes = 5;
        for (int i = 0; i < numberOfShapes; i++)
        {
            CreateShape();

            newShape.tag = "wall";
            SpriteRenderer shapeRenderer = newShape.GetComponent<SpriteRenderer>();
            var rigidbody = newShape.AddComponent<Rigidbody2D>();
            rigidbody.gravityScale = 0;

            if (shapeRenderer != null)
            {
                shapeRenderer.color = shapeColor;
            }

            float randomSize = Random.Range(1f, 3f);
            newShape.transform.localScale = new Vector3(randomSize, randomSize, 1f);

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

    private void DestroyExistingShapes()
    {
        GameObject[] existingShapes = GameObject.FindGameObjectsWithTag("wall"); 
        foreach (GameObject shape in existingShapes)
        {
            Destroy(shape);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float cameraHeight = 2f * Camera.main.orthographicSize * 0.9f;
        float cameraWidth = cameraHeight * Camera.main.aspect * 0.9f;

        float randomX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
        float randomY = Random.Range(-cameraHeight / 2f, cameraHeight / 2f);

        return new Vector3(randomX, randomY, 0f);
    }
}