using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that manage the change of scene in the game.
/// </summary>
public class ChangeScene : MonoBehaviour
{
    /// <summary>
    /// Function that manage the change of scenes across the game.
    /// </summary>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
