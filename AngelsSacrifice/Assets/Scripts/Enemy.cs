using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] doorPositions = new GameObject[3];
    public GameObject smitePrefab;

    public float moveSpeed = 3f;
    public int health = 1;
    public int faithDamage = 1;
    public int scoreValue = 1;
    public int faithValue = 1;

    public int dir = 1;

    private float walkheight;
    private bool paused = false;

    // Start is called before the first frame update
    private void Start()
    {
        Vector3 spawnPoint = doorPositions[(int)(Random.value * 2.9f)].transform.position;
        transform.position = spawnPoint;

        if (spawnPoint.x == doorPositions[0].transform.position.x)
            dir = 1;
        else if (spawnPoint.x == doorPositions[2].transform.position.x)
            dir = -1;
        else
        {
            if (Random.value < .5f)
                dir = -1;
            else
                dir = 1;
        }

        if (dir > 0)
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z, transform.rotation.w);
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 ScreenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        if(transform.position.x + .2f > ScreenSize.x || transform.position.x - .2f < -ScreenSize.x)
        {
            LevelManager.Instance.EscapedEnemy(faithDamage);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (LevelManager.Instance.IsPaused())
            return;

        if(transform.position.y > walkheight)
        {
            transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.position += new Vector3(moveSpeed * dir * Time.deltaTime, 0, 0);
        }
    }

    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject smite = Instantiate(smitePrefab);
            smite.transform.position = transform.position;
            Destroy(smite, 2);
            LevelManager.Instance.EnemySmote(scoreValue, faithValue);
        }
        LevelAudioManager.Instance.PlayStrike();
    }

    public void RandomiseWalkHeight(float min, float max)
    {
        walkheight = Random.Range(min, max);
    }
}
