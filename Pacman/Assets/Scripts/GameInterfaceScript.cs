using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class that manage the change of scene in the game.
/// </summary>
public class GameInterface : MonoBehaviour
{
    /// <summary>
    /// Represents the TextMeshProGui that shows the first highscore.
    /// </summary>
    public TextMeshProUGUI highScoreText1;

    /// <summary>
    /// Represents the TextMeshProGui that shows the second highscore.
    /// </summary>
    public TextMeshProUGUI highScoreText2;

    /// <summary>
    /// Represents the TextMeshProGui that shows the third highscore.
    /// </summary>
    public TextMeshProUGUI highScoreText3;

    public Button musicButton;
    public Button soundEffectsButton;
    private ColorBlock activeColor;
    private ColorBlock deactivateColor;

    /// <summary>
    /// Boolean that handles if the sound effects have to be reproduce.
    /// </summary>
    public static bool soundEffect;

    void Start()
    {
        try
        {
            //activeColor = musicButton.colors.normalColor;
            //deactivateColor = musicButton.colors.disabledColor;
            if (SceneManager.GetActiveScene().name == "RecordsScene")
            {
                ShowScores();
            }

            if (PlayerPrefs.GetString("Sound").Equals("true"))
            {
                soundEffect = true;
            } else
            {
                soundEffect = false;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    /// <summary>
    /// Function that manage the change of scenes across the game.
    /// </summary>
    public void LoadScene(string sceneName)
    {
        try
        {
            SceneManager.LoadScene(sceneName);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Change the color of the button when you interact to it.
    /// </summary>
    /// <param name="sender">The button that has to change the color.</param>
    /// <param name="active">Boolean that determines if you activate the button or not.</param>
    public void ChangeButtonColor(Button sender, bool active)
    {
        if (active)
        {
            ColorBlock colors = sender.colors;
            colors.normalColor = activeColor.normalColor;
            sender.colors = colors;
        }
        else
        {
            sender.colors = deactivateColor;
        }
    }

    /// <summary>
    /// Funtion that handles the music of the game.
    /// </summary>
    public void MusicHandler()
    {
        try
        {
            if (PlayerPrefs.HasKey("Music"))
            {
                if (PlayerPrefs.GetString("Music").Equals("true"))
                {
                    // play music 
                    // change color to the actual color
                    ChangeButtonColor(musicButton, true);
                    PlayerPrefs.SetString("Music", "true");

                }
                else
                {
                    ChangeButtonColor(musicButton, false);
                    PlayerPrefs.SetString("Music", "False");
                    // pause music 
                    // change color to dark
                }
            }
            else
            {

            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Function that handles the sound effects of the game.
    /// </summary>
    public void SoundEffectHandler()
    {
        try
        {
            if (PlayerPrefs.HasKey("Sound"))
            {
                if (PlayerPrefs.GetString("Sound").Equals("true"))
                {
                    // activated boolean
                    // change color to the actual color
                }
                else
                {
                    // diactivated boolean
                    // change color to dark
                }
            }
            else
            {

            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    /// <summary>
    /// Function that shows the records of the game.
    /// </summary>
    public void ShowScores()
    {
        try
        {
            if (PlayerPrefs.HasKey("HS1"))
            {
                highScoreText1.text = "1st: " + PlayerPrefs.GetInt("HS1");
            }
            else
            {
                highScoreText1.text = "No record";
            }

            if (PlayerPrefs.HasKey("HS2"))
            {
                highScoreText2.text = "2nd: " + PlayerPrefs.GetInt("HS2");
            }
            else
            {
                highScoreText2.text = "No record";
            }

            if (PlayerPrefs.HasKey("HS3"))
            {
                highScoreText3.text = "3rd: " + PlayerPrefs.GetInt("HS3");
            }
            else
            {
                highScoreText3.text = "No record";
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
