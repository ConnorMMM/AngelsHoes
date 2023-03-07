using BLASTER_RIVALS.DesignPatterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public int score = 0;
    public float faith = 50;
    public int maxFaith = 100;

    public float scoreTimeStep = 0;

    public bool gameOver = false;
    public bool pause;

    public Scrollbar faithMeter;
    public Text scoreText;

    public GameObject playMenu;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    private void Awake()
    {
        base.Awake();

        gameOver = false;
        pause = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (pause)
            return;

        faithMeter.size = (100 - faith) / 100.0f;
        scoreText.text = $"Score: {score}";

        if (faith <= 0)
        {
            faith = 0;
            gameOver = true;
            playMenu.SetActive(false);
            gameOverMenu.SetActive(true);
        }

        if (!gameOver)
        {
            scoreTimeStep += Time.deltaTime;
            if (scoreTimeStep > 1)
            {
                scoreTimeStep = 0;
                score++;
                faith -= .5f;
            }
        }
        else
        {

        }
    }

    public void EscapedEnemy(int faithDamage)
    {
        faith -= faithDamage;
        
    }

    public void EnemySmote(int scoreValue, int faithValue)
    {
        score += scoreValue;
        faith += faithValue;
        if(faith > maxFaith)
            faith = maxFaith;
    }

    public void PauseGame(bool state)
    {
        pause = state;
        pauseMenu.SetActive(state);
    }

    public bool IsGameOver() { return gameOver; }
    public bool IsPaused() { return pause; }
}
