using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BasicMovement : MonoBehaviour
{
    private NavMeshAgent nma;

    public float speed;

    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector2 movementThisFrame = (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))).normalized;
        nma.Move(new Vector3(movementThisFrame.x, 0f, movementThisFrame.y) * speed * Time.deltaTime);
    }
}
