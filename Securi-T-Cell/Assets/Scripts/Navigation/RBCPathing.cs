using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RBCPathing : MonoBehaviour
{
    public RBCNexus target;

    private NavMeshAgent nma;

    private ForceRegionAcceptor fra;

    void Start()
    {
        nma = GetComponent<NavMeshAgent>();

        fra = GetComponent<ForceRegionAcceptor>();
    }

    public void SetTarget(RBCNexus argTarget)
    {
        fra.forceRatio = .4f;
        target = argTarget;
        nma.SetDestination(target.transform.position);
    }
}
