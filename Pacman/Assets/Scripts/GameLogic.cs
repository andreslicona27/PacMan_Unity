using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

/// <summary>
/// In charge of control the logic of the game.
/// </summary>
public class GameLogic : MonoBehaviour
{
    public string scoreLabel;
    public int score;
    public bool gameRunning;
    public PlayerMovement pacman;
    public CoinMovement coin;
    public Text scoreUI;


    /// <summary>
    /// Initialice the components that are need int the game.
    /// </summary>
    void Start()
    {
        try
        {
            score = 0;
            gameRunning = true;

            pacman = FindObjectOfType<PlayerMovement>();
            coin = FindObjectOfType<CoinMovement>();
            scoreUI = FindObjectOfType<Text>();
        }
        catch (System.Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
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
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
        }
    }

    // if pacman collisions with coin increase score and update change game variable 
    // if pacman touch ghost its game over change bool variable 

    // if score divided by 5 increase enemies speed 
    // if score divided by 10 change maze 
    // if score divided by 20 increase enemies 

    public void AddPoint()
    {
        score++;
        scoreUI.text = "Score: " + score.ToString();
    }

}
