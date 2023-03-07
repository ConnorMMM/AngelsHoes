using BLASTER_RIVALS.DesignPatterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : Singleton<SceneManager>
{
    public int score = 0;
    public int faith = 50;
    public int maxFaith = 100;

    public float scoreTimeStep = 0;

    public bool gameOver = false;

    private void Awake()
    {
        base.Awake();


        gameOver = false;
    }

    // Update is called once per frame
    private void Update()
    {
        scoreTimeStep += Time.deltaTime;
        if(scoreTimeStep > 1)
        {
            scoreTimeStep = 0;
            score++;
            faith--;
        }
    }

    public void EscapedEnemy(int faithDamage)
    {
        faith -= faithDamage;
        if(faith <= 0)
        {
            faith = 0;
            gameOver = true;
        }
    }

    public void EnemySmote(int scoreValue, int faithValue)
    {
        score += scoreValue;
        faith += faithValue;
    }
}
