using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject[] doorPositions = new GameObject[3];
    public GameObject[] enemyPrefabs;

    public float timeStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeStep += Time.deltaTime;
        
        if(timeStep > 1)
        {
            timeStep = 0;

            int index = (int)(Random.value * 2);

            if (enemyPrefabs[index])
            {
                GameObject enemy = Instantiate(enemyPrefabs[index]);
                enemy.GetComponent<Enemy>().doorPositions = doorPositions;
            }
        }
    }
}
