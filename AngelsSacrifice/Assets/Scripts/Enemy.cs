using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    private void Start()
    {
        Vector3 spawnPoint = doorPositions[(int)(Random.value * 2)].transform.position;
        spawnPoint.y += Random.value * -3;
        transform.position = spawnPoint;

        if (spawnPoint.x < 0)
            dir = 1;
        else if (spawnPoint.x > 0)
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
            SceneManager.Instance.EscapedEnemy(faithDamage);
            Destroy(gameObject);
        }
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
            GameObject smite = Instantiate(smitePrefab);
            smite.transform.position = transform.position;
            Destroy(smite, 2);
            SceneManager.Instance.EnemySmote(scoreValue, faithValue);
        }
    }
}
