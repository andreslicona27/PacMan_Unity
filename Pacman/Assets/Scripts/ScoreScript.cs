using System;
using TMPro;
using UnityEngine;

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
        try
        {
            scoreValue = 0;
            scoreText = GetComponent<TextMeshProUGUI>();
        }
        catch(NullReferenceException ex)
        {
            Debug.LogError("Null reference exception: " + ex.Message);
        }
        catch (MissingComponentException ex)
        {
            Debug.LogError("Missing component error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Debug.LogError("General error: " + ex.Message);
        }
    }

    /// <summary>
    /// Updates the score label during the game.
    /// </summary>
    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
    }
}
