using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemySpawning : MonoBehaviour
{
    public GameObject[] doorPositions = new GameObject[3];
    public GameObject[] enemyPrefabs;
    public GameObject walkBox;

    public float timeStep = 0;

    public float timeStepMax = 2;
    public float SpawnRateIncreaser = .03f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance.IsPaused())
            return;

        timeStep += Time.deltaTime;
        
        if(timeStep > timeStepMax)
        {
            timeStep = 0;

            int index = (int)(Random.value * 2 + 0.2f);

            if (enemyPrefabs[index])
            {
                GameObject enemy = Instantiate(enemyPrefabs[index]);
                Enemy enemyScripts = enemy.GetComponent<Enemy>();
                enemyScripts.doorPositions = doorPositions;
                enemyScripts.RandomiseWalkHeight(walkBox.transform.position.y - walkBox.transform.localScale.y / 2.0f, walkBox.transform.position.y + walkBox.transform.localScale.y / 2.0f);
            }

            timeStepMax -= SpawnRateIncreaser * (timeStepMax - .1f);
            if (timeStepMax < 0.15)
                timeStepMax = 0.15f;
        }
    }
}
