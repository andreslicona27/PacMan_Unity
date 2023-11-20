using System;
using TMPro;
using UnityEngine;

/// <summary>
/// Class maange the game over scene and shows the score the player obtain 
/// </summary>
public class GameOverScript : MonoBehaviour
{
    /// <summary>
    /// Used to reference the component that shows the score that you get
    /// </summary>
    public TextMeshProUGUI scoreText;

    /// <summary>
    /// Initialized the values of the components 
    /// </summary>
    void Start()
    {
        try
        { 
            if (scoreText != null)
            {
                scoreText.text = "Score: " + PlayerPrefs.GetInt("score");
            }
            else
            {
                Debug.LogError("scoreText is not assigned in the Inspector.");
            }
        }
        catch (MissingComponentException ex)
        {
            Debug.LogError("Missing component error: " + ex.Message);
        }
        catch(NullReferenceException ex)
        {
            Debug.LogError("Null Reference Exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Debug.LogError("General error: " + ex.Message);
        }
    }
}
