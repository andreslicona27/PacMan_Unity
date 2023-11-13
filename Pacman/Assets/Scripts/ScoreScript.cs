using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

/// <summary>
/// Class that handles the score label properties.
/// </summary>
public class ScoreScript : MonoBehaviour
{
    /// <summary>
    /// Represent the integer score value.
    /// </summary>
    public static int scoreValue;

    /// <summary>
    /// Used to reference the component that shows the score label during the game.
    /// </summary>
    public TextMeshProUGUI scoreText;
   
    /// <summary>
    /// Initialized the class components 
    /// </summary>
    void Start()
    {
        scoreValue = 0;
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Updates the score label during the game.
    /// </summary>
    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
    }
}
