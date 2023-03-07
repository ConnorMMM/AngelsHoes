using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public void Pause()
    {
        LevelManager.Instance.PauseGame(true);
    }

    public void Resume()
    {
        LevelManager.Instance.PauseGame(false);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
