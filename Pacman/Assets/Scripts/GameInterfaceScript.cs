using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that manage the change of scene in the game.
/// </summary>
public class GameInterface : MonoBehaviour
{
    /// <summary>
    /// Boolean that handles if the sound effects have to be reproduce.
    /// </summary>
    public static bool soundEffect;

    /// <summary>
    /// Array that manage the highscores text.
    /// </summary>
    public TextMeshProUGUI[] highScores;

    /// <summary>
    /// Reference the music button text
    /// </summary>
    public TextMeshProUGUI musicText;

    /// <summary>
    /// Reference the sound button text
    /// </summary>
    public TextMeshProUGUI soundText;

    /// <summary>
    /// Reference to the audioManager to handle the sound in the click.
    /// </summary>
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    /// <summary>
    /// Initialized the code in class 
    /// </summary>
    void Start()
    {
        try
        {
            if (SceneManager.GetActiveScene().name == "Records")
            {
                ShowScores();
            }
        }
        catch (PlayerPrefsException playerPrefsEx)
        {
            Debug.LogError("PlayerPrefs error: " + playerPrefsEx.Message);
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError("Index out of range: " + e.Message);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error in Start(): " + ex.Message);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Settings")
        {
            UpdateMusicButton();
            UpdateSoundButton();
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
        catch (NullReferenceException e)
        {
            Debug.LogError("Null Reference Exception in load scene: " + e.Message);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error loading scene: " + ex.Message);
        }
    }

    /// <summary>
    /// Function that shows the records of the game.
    /// </summary>
    public void ShowScores()
    {
        try
        {
            for (int i = 0; i < highScores.Length; i++)
            {
                string key = "HS" + (i + 1);

                if (PlayerPrefs.HasKey(key))
                {
                    highScores[i].text = $"{i + 1}: " + PlayerPrefs.GetInt(key);
                }
                else
                {
                    highScores[i].text = "No record";
                }
            }
        }
        catch (PlayerPrefsException playerPrefsEx)
        {
            Debug.LogError("PlayerPrefs error: " + playerPrefsEx.Message);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error in ShowScores(): " + ex.Message);
        }
    }

    /// <summary>
    /// Function that handles when we actived or deactived the music 
    /// </summary>
    public void ActiveMusic()
    {
        try
        {
            if (PlayerPrefs.GetInt("Music") == 1)
            {
                PlayerPrefs.SetInt("Music", 0);
                audioManager.MusicHandler(false);
            }
            else
            {
                PlayerPrefs.SetInt("Music", 1);
                audioManager.MusicHandler(true);
            }
        }
        catch (PlayerPrefsException playerPrefsEx)
        {
            Debug.LogError("PlayerPrefs error: " + playerPrefsEx.Message);
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError("Index out of range: " + e.Message);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Null Reference Exception in ActiveMusic: " + e.Message);
        }
    }

    /// <summary>
    /// Function that handles when we actived or deactived the sound effects
    /// </summary>
    public void ActiveSound()
    {
        try
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {
                PlayerPrefs.SetInt("Sound", 0);
            }
            else
            {
                PlayerPrefs.SetInt("Sound", 1);
            }
        }
        catch (PlayerPrefsException playerPrefsEx)
        {
            Debug.LogError("PlayerPrefs error: " + playerPrefsEx.Message);
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError("Index out of range: " + e.Message);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Null Reference Exception in ActiveSound: " + e.Message);
        }
    }

    /// <summary>
    /// Function that plays the sound of the button 
    /// </summary>
    public void PlayClickSound()
    {
        try
        {
            audioManager.PlaySFX(audioManager.clickButton);
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Null Reference exception in playsound" + e.ToString());
        }
    }

    /// <summary>
    /// Function that update the text inside the music button based on the PlayerPrefs
    /// </summary>
    private void UpdateMusicButton()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            musicText.text = "Music OFF";
        }
        else
        {
            musicText.text = "Music ON";
        }
    }

    /// <summary>
    /// Function that update the text inside the sound effects button based on the PlayerPrefs
    /// </summary>
    private void UpdateSoundButton()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            soundText.text = "Sound Effects OFF";
        }
        else
        {
            soundText.text = "Sound Effects ON";
        }
    }

    /// <summary>
    /// Function that exits the game
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
