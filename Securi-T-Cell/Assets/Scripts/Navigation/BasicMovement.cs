using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BasicMovement : MonoBehaviour
{
    private NavMeshAgent nma;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementThisFrame = (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))).normalized;
        Debug.Log(movementThisFrame);
        nma.Move(new Vector3(movementThisFrame.x, 0f, movementThisFrame.y) * speed * Time.deltaTime);
    }
}
