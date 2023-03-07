using BLASTER_RIVALS.DesignPatterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAudioManager : Singleton<LevelAudioManager>
{
    public AudioSource SmiteYouScream;
    public AudioSource gameloop;
    public AudioSource strike;
    public AudioSource gameOver;
    public AudioSource lowFaith;

    private float time;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        SmiteYouScream.Play();
        time = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameloop.isPlaying && !isGameOver)
        {
            time += Time.deltaTime;
            if (time > 2.3f)
                gameloop.Play();
        }
        
    }

    public void PlayStrike() { strike.Play(); }
    
    public void GameOver()
    {
        gameOver.Play();
        gameloop.Stop();
        isGameOver = true;
    }
    public void PlayLowFaith() { lowFaith.Play(); }
}
