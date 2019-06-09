using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyIdle: MonoBehaviour
{
    private NavMeshAgent nma;
    private float idleTime = 20;
    private float actionIntervals = 5;
    private float timer = 0;
    private float last = 0;
    private bool moving = false;
    public float wanderDistance = 100;

    // Start is called before the first frame update
    void Awake()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= idleTime)
        {
            timer = 0;
            last = 0;
            GetComponent<BigEnemyMovement>().enabled = true;
            this.enabled = false;
            nma.isStopped = false;
        }

        else if (timer >= last + actionIntervals)
        {
            last += actionIntervals;
            if (moving)
            {
                nma.isStopped = true;
                moving = false;
            }
            else
            {
                nma.isStopped = false;
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + Random.insideUnitSphere * wanderDistance, out navHit, wanderDistance, -1);
                nma.SetDestination(navHit.position);
                moving = true;
            }
        }
    }
}
