using UnityEngine;

/// <summary>
/// Class that handles all the audio of the game .
/// </summary>
public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    /// <summary>
    /// Represents the audio source of the music.
    /// </summary>
    [SerializeField] AudioSource musicSource;

    /// <summary>
    /// Rerpesents the audio source of the sound effects.
    /// </summary>
    [SerializeField] AudioSource soundEffectSource;

    [Header("-----Audio Clip-----")]
    /// <summary>
    /// Rerpesents the music clip.
    /// </summary>
    public AudioClip background;

    /// <summary>
    /// Represents the sound effect when pacman dies.
    /// </summary>
    public AudioClip death;

    /// <summary>
    /// Rerpesents the start sound effect it sound when pacman eats a coin.
    /// </summary>
    public AudioClip eatCoin;

    /// <summary>
    /// Rerpesents the start change maze sound effect.
    /// </summary>
    public AudioClip changeMaze;

    /// <summary>
    /// Rerpesents the start button click sound effect. 
    /// </summary>
    public AudioClip clickButton;

    /// <summary>
    /// Rerpesents the start game sound effect.
    /// </summary>
    public AudioClip startGame;

    /// <summary>
    /// Reference the instance of the audiomanager .
    /// </summary>
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    /// <summary>
    /// Initialized the values of the sounds 
    /// </summary>
    private void Start()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            if (PlayerPrefs.GetInt("Music") == 1)
            {
                musicSource.clip = background;
                musicSource.Play();
            }
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
            musicSource.clip = background;
            musicSource.Play();
        }

        if (!PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {
                GameInterface.soundEffect = true;
            }
            else
            {
                GameInterface.soundEffect = false;
            }
        }
    }

    /// <summary>
    /// Function that handles the sound effects of the game.
    /// </summary>
    public void PlaySFX(AudioClip clip)
    {
        try
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {
                soundEffectSource.clip = clip;
                soundEffectSource.PlayOneShot(clip);
            }
        }
        catch (PlayerPrefsException playerPrefsEx)
        {
            Debug.LogError("PlayerPrefs error: " + playerPrefsEx.Message);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error in SoundEffectHandler(): " + ex.Message);
            Debug.LogException(ex);
        }
    }

    /// <summary>
    /// Funtion that handles the music of the game.
    /// </summary>
    public void MusicHandler(bool music)
    {
        try
        {
            if (music)
            {
                musicSource.clip = background;
                musicSource.Play();
            }
            else
            {
                musicSource.Pause();
            }
        }
        catch (PlayerPrefsException playerPrefsEx)
        {
            Debug.LogError("PlayerPrefs error: " + playerPrefsEx.Message);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error in MusicHandler(): " + ex.Message);
            Debug.LogException(ex);
        }
    }
}
