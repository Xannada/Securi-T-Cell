using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RBCPathing : MonoBehaviour
{
    public RBCNexus target;

    private NavMeshAgent nma;

    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    public void SetTarget(RBCNexus argTarget)
    {
        target = argTarget;
        nma.SetDestination(target.transform.position);
    }
}
