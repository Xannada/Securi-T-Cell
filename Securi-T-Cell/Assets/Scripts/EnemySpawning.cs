using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    private float timer = 0;
    private float spawnTime = 10;
    private float spawnCount = 3;
    public GameObject enemy;

    private void Awake()
    {
        if (!enemy) enemy = Resources.Load("Enemy2D") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            for (int i = 0; i < spawnCount; i++)
                Instantiate(enemy, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
