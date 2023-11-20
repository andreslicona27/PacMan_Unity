using System;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// In charge of control the logic of the game.
/// </summary>
public class GameLogic : MonoBehaviour
{
    /// <summary>
    /// Variable that references the coin during the game.
    /// </summary>
    public CoinScript coin;

    /// <summary>
    /// Variable that references maze during the game.
    /// </summary>
    public MazeScript maze;

    /// <summary>
    /// Variable that controls when the game is running.
    /// </summary>
    public static bool gameRunning = false;

    /// <summary>
    /// References the Pause panel so it can handle when to show it.
    /// </summary>
    public GameObject panelPause;

    /// <summary>
    /// References the audioManager for it to handle all the sound effects of the game
    /// </summary>
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    /// <summary>
    /// Initialice the components that are need int the game.
    /// </summary>
    void Start()
    {
        try
        {
            if (SceneManager.GetActiveScene().name == "Game")
            {
                coin = FindObjectOfType<CoinScript>();
                if (coin == null)
                {
                    Debug.LogError("CoinScript not found in the scene.");
                }
                maze = FindObjectOfType<MazeScript>();
                if (maze == null)
                {
                    Debug.LogError("MazeScript not found in the scene.");
                }
                else
                {
                    maze.GenerateMaze();
                }
                audioManager.PlaySFX(audioManager.startGame);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    /// <summary>
    /// Verifies if the player tries to start the game or to pause it
    /// </summary>
    private void Update()
    {
        if (gameRunning)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameRunning = true;
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
                audioManager.PlaySFX(audioManager.eatCoin);
                ScoreScript.scoreValue++;
                GhostScript.speed += 0.05f;
                ChangeGame(ScoreScript.scoreValue);
            }

            if (collision.gameObject.CompareTag("pacman") && collision.otherCollider.gameObject.CompareTag("ghost"))
            {
                audioManager.PlaySFX(audioManager.death);
                SafeScore();
                PlayerPrefs.SetInt("score", ScoreScript.scoreValue);
                SceneManager.LoadScene("GameOver");
            }
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("Null Reference in OnCollisionEnter2D: " + e.ToString());
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Increase the level of the game depending on the score by one of this options:
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
                maze.GenerateMaze();
                audioManager.PlaySFX(audioManager.changeMaze);
            }

            if (score % 20 == 0)
            {
                if (GhostScript.ghostNumber <= 7)
                {
                    GhostScript.ghostNumber++;
                }
            }
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("Null Reference in ChangeGame: " + e.ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Unknown Exception in ChangeGame: " + e.ToString());
        }
    }

    /// <summary>
    /// Pause the game and shows the pause panel 
    /// </summary>
    public void PauseGame()
    {
        try
        {
            gameRunning = false;
            panelPause.SetActive(true);
            Time.timeScale = 0;
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("Null Reference in PauseGame: " + e.ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Unknown Exception in PauseGame: " + e.ToString());
        }
    }

    /// <summary>
    /// Unpause the game and resumes the game 
    /// </summary>
    public void UnpauseGame()
    {
        try
        {
            gameRunning = true;
            panelPause.SetActive(false);
            Time.timeScale = 1;
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("Null Reference in PauseGame: " + e.ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Unknown Exception in PauseGame: " + e.ToString());
        }
    }

    /// <summary>
    /// Save the score in case it becomes a high score.
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
                if (score1 != score2)
                {
                    PlayerPrefs.SetInt("HS2", ScoreScript.scoreValue);
                }
            }
            else if (ScoreScript.scoreValue > score3)
            {
                if (score2 != score3)
                {
                    PlayerPrefs.SetInt("HS3", ScoreScript.scoreValue);
                }
            }
        }
        catch (PlayerPrefsException e)
        {
            Debug.LogError("PlayerPrefs Exception in SafeScore: " + e.ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Unknown Exception in SafeScore: " + e.ToString());
        }
    }
}
