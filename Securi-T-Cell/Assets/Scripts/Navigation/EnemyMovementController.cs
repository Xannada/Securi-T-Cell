using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovementController : MonoBehaviour
{
    private NavMeshAgent nma;
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nma.SetDestination(player.transform.position);
    }
}
