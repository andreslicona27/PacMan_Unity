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
    /// <summary>
    /// Variable that references the coin during the game.
    /// </summary>
    public CoinScript coin;

    public MazeScript maze;

    /// <summary>
    /// Variable that controls when the game is running.
    /// </summary>
    public static bool gameRunning;


    public GameObject panelGameOver;
    public GameObject panelPause;
    public AudioSource AudioSource;
    public AudioClip deadclip;

    /// <summary>
    /// Initialice the components that are need int the game.
    /// </summary>
    void Start()
    {
        try
        {
            gameRunning = true;
            coin = FindObjectOfType<CoinScript>();
            maze = FindObjectOfType<MazeScript>();
            //AudioSource = GetComponent<AudioSource>();
            //if (deadAudioSource == null)
            //{
            //    Debug.LogError("AudioSource not found on the object.");
            //}
            maze.GenerateShapes();

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
                GhostScript.speed += 0.05f;
                ChangeGame(ScoreScript.scoreValue);
            }

            if (collision.gameObject.CompareTag("pacman") && collision.otherCollider.gameObject.CompareTag("ghost"))
            {
                if (GameInterface.soundEffect)
                {

                }
                AudioSource.clip = deadclip;
                AudioSource.Play();
                GameOver();
                SafeScore();
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
            if (score % 10 == 0)
            {
                maze.GenerateShapes();
            }
            else if (score % 20 == 0)
            {
                if (GhostScript.ghostNumber <= 7)
                {
                    Debug.Log("Increase ghosts");
                    GhostScript.ghostNumber++;
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Handles the game over panel and the boolean variable of the game.
    /// </summary>
    public void GameOver()
    {
        try
        {
            gameRunning = !gameRunning;
            panelGameOver.SetActive(!gameRunning);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Handles when to pause the game and if the pause panel is showing or not.
    /// </summary>
    public void PauseGame()
    {
        try
        {
            gameRunning = !gameRunning;
            panelPause.SetActive(!gameRunning);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Safe the score in cause that it has become a highscore.
    /// </summary>
    public void SafeScore()
    {
        try
        {
            int score1 = PlayerPrefs.GetInt("HS1");
            int score2 = PlayerPrefs.GetInt("HS2");
            int score3 = PlayerPrefs.GetInt("HS3");

            if (ScoreScript.scoreValue > score1)
            {
                PlayerPrefs.SetInt("HS1", ScoreScript.scoreValue);
            }
            else if (ScoreScript.scoreValue > score2)
            {
                PlayerPrefs.SetInt("HS2", ScoreScript.scoreValue);
            }
            else
            {
                PlayerPrefs.SetInt("HS3", ScoreScript.scoreValue);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
