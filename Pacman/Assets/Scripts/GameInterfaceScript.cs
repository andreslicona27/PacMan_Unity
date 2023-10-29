using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that manage the change of scene in the game.
/// </summary>
public class GameInterface : MonoBehaviour
{
    /// <summary>
    /// Function that manage the change of scenes across the game.
    /// </summary>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Funtion that handles the music of the game.
    /// </summary>
    public void MusicHandler()
    {

    }

    /// <summary>
    /// Function that handles the sound effects of the game.
    /// </summary>
    public void SoundEffectHandler()
    {

    }
}
