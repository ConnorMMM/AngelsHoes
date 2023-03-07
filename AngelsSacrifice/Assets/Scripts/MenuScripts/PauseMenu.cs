using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI; 

    
    public void Pause()
    {
        LevelManager.Instance.PauseGame(true);
    }

    public void Resume()
    {
        LevelManager.Instance.PauseGame(false);
    }
}
