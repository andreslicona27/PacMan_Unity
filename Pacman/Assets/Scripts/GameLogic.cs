using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

/// <summary>
/// In charge of control the logic of the game.
/// </summary>
public class GameLogic : MonoBehaviour
{
    public PacmanScript pacman;
    public CoinScript coin;
    public static bool gameRunning;

    /// <summary>
    /// Initialice the components that are need int the game.
    /// </summary>
    void Start()
    {
        try
        {
            gameRunning = true;
            coin = FindObjectOfType<CoinScript>();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {

        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Handles the collision of the elements during the game
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            if (collision.gameObject.CompareTag("pacman") && collision.otherCollider.gameObject.CompareTag("coin"))
            {

                coin.RandomPosition();
                ScoreScript.scoreValue++;
                ChangeGame(ScoreScript.scoreValue);
            }

            if (collision.gameObject.CompareTag("pacman") && collision.otherCollider.gameObject.CompareTag("ghost"))
            {
                Debug.Log("We lost");
                //gameRunning = false;

                // Show gameover board 
                // ask to replay or home page 
                // Safe score and see if its a highscore 
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Increase the level of the game depending on the score by one of this options:
    /// - Increasing enemies speed
    /// - Changing the maze
    /// - Adding a new ghost
    /// </summary>
    /// <param name="score"></param> Used to determined what option would be 
    public void ChangeGame(int score)
    {
        try
        {
            // if score divided by 5 increase enemies speed 
            // if score divided by 10 change maze 
            // if score divided by 20 increase enemies
            if (score % 5 == 0 && score % 10 != 0)
            {
                GhostScript.speed += 1f;
                Debug.Log("increase speed");
            }
            else if (score % 10 == 0)
            {
                //ChangeGame Maze code
            }
            else if (score % 20 == 0)
            {
                if (GhostScript.ghostNumber <= 7)
                {
                    GhostScript.ghostNumber++;
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
