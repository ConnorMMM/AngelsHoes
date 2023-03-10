using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int clickDamage = 1;

    void Update()
    {
        if (LevelManager.Instance.IsGameOver())
            return;

        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            LevelManager.Instance.PauseGame(!LevelManager.Instance.IsPaused());
            return;
        }

        if (LevelManager.Instance.IsPaused())
            return;


        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit)
            {
                Debug.Log(hit.collider.gameObject.name);
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if(enemy)
                {
                    enemy.Hit(clickDamage);
                }
            }
        }
    }
}
