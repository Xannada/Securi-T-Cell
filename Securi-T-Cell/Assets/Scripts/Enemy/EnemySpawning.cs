using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    private float timer = 0;
    private static GameObject spawn;
    private float spawnTime = 10;
    private int spawnCount = 3;
    private int spawnLimit = 300;
    public GameObject enemy;

    private void Awake()
    {
        if (!enemy) enemy = Resources.Load("Enemy2D") as GameObject;
    }

    private void Start()
    {
        if (!spawn)
        {
            if (GameObject.Find("Small Enemies")) spawn = GameObject.Find("Small Enemies");
            else spawn = Instantiate(new GameObject("Small Enemies"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            int limit = Mathf.Min(spawnCount, spawnLimit - spawn.transform.childCount + spawnCount);
            for (int i = 0; i < limit; i++)
            {
                Instantiate(enemy, transform.position, Quaternion.identity, spawn.transform);
            }
            timer = 0;
        }
    }
}
