using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] doorPositions = new GameObject[3];

    public float moveSpeed = 3f;
    public int health = 1;

    public int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPoint = doorPositions[(int)(Random.value * 2)].transform.position;
        spawnPoint.y += Random.value * -3;
        transform.position = spawnPoint;

        if(spawnPoint.x < 0)
            dir = 1;
        if (spawnPoint.x > 0)
            dir = -1;
        else
        {
            if (Random.value < .5f)
                dir = -1;
            else
                dir = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(moveSpeed * dir * Time.deltaTime, 0, 0);
    }

    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
