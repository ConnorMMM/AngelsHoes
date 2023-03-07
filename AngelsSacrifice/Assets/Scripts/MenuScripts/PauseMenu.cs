using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
<<<<<<< HEAD
=======
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI; 

    
>>>>>>> 91f33280766ead03e87fa80574b588760d52aa8f
    public void Pause()
    {
        LevelManager.Instance.PauseGame(true);
    }

    public void Resume()
    {
        LevelManager.Instance.PauseGame(false);
<<<<<<< HEAD
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
=======
>>>>>>> 91f33280766ead03e87fa80574b588760d52aa8f
    }
}
