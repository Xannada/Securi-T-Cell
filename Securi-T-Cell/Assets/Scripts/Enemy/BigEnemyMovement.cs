﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BigEnemyMovement : MonoBehaviour
{
    private NavMeshAgent nma;
    private EnemyStats stats;
    private GameObject player;
    private GameObject EnemyParentInScene;
    private GameObject infecting = null;
    private float timer = 0;
    public float eatTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        stats = GetComponent<EnemyStats>();
        EnemyParentInScene = GameObject.Find("Enemies");
    }

    public void respawn()
    {
        if (infecting)
        {
            Instantiate(Resources.Load("BloodCell"), transform.position, Quaternion.identity); // If destroyed while infecting
        }
        GameObject nexi = GameObject.Find("RBCNexi");
        if (nexi)
        {
            int randomNexus = Random.Range(0, nexi.transform.childCount);
            Vector3 spawnPos = nexi.transform.GetChild(randomNexus).transform.position;
            Instantiate(Resources.Load("BloodCell"), spawnPos, Quaternion.identity);
        }
        else Instantiate(Resources.Load("BloodCell"));
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.readyToDie) this.enabled = false;

        if (infecting)
        {
            timer += Time.deltaTime;
            if (timer >= eatTime)
            {
                Destroy(infecting);
                infecting = null;
                nma.isStopped = false;
                timer = 0;
                if (EnemyParentInScene) Instantiate(Resources.Load("Enemy2DLarge"), transform.position, Quaternion.identity, EnemyParentInScene.transform);
                else Instantiate(Resources.Load("Enemy2DLarge"), transform.position, Quaternion.identity);
                GetComponent<EnemyIdle>().enabled = true;
                GetComponent<EnemyIdle>().StartIdling();
                this.enabled = false;
            }
        }
        else
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Ally");
            GameObject closest = null;

            foreach (GameObject target in targets)
            {
                float distance = Vector3.Distance(target.transform.position, transform.position);

                if (closest == null || distance < Vector3.Distance(closest.transform.position, transform.position))
                {
                    closest = target;
                }
            }

            if (closest != null) nma.SetDestination(closest.transform.position);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (this.enabled && col.transform.CompareTag("Ally"))
        {
            if (!infecting)
            {
                infecting = Instantiate(Resources.Load("GenericCell"), transform) as GameObject;
                infecting.GetComponentInChildren<SpriteRenderer>().color = col.collider.GetComponentInChildren<SpriteRenderer>().color - new Color(0, 0, 0, .5f);
                infecting.transform.localPosition = Vector3.up;
                nma.isStopped = true;
                Destroy(col.transform.gameObject);
            }
        }
    }
}
