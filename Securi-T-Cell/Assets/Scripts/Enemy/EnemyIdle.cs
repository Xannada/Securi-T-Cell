using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyIdle: MonoBehaviour
{
    private NavMeshAgent nma;
    private float idleTime = 20;
    private float timer = 0;
    public RBCNexus target;

    private ForceRegionAcceptor fra;

    private float chaseSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        nma = GetComponent<NavMeshAgent>();
        fra = GetComponent<ForceRegionAcceptor>();

        StartIdling();
    }

    public void StartIdling()
    {
        //GetComponent<Rigidbody>().isKinematic = false;
        fra.forceRatio = 2;
        chaseSpeed = nma.speed; //save the desired speed for later
        nma.speed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= idleTime)
        {
            timer = 0;
            //GetComponent<Rigidbody>().isKinematic = true;
            nma.speed = chaseSpeed;
            GetComponent<BigEnemyMovement>().enabled = true;
            this.enabled = false;
            nma.isStopped = false;
        }
    }
    
    public void SetTarget(RBCNexus argTarget)
    {
        fra.forceRatio = .4f;
        target = argTarget;
        nma.SetDestination(target.transform.position);
    }
}
