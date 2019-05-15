using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceRegion : MonoBehaviour
{
    [SerializeField] protected float force_Strength;
    private Rigidbody2D m_RigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_RigidBody2D = collision.gameObject.GetComponent<Rigidbody2D>();
        //Debug.Log("Enter");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        m_RigidBody2D.AddForce(transform.right * force_Strength);
        //Debug.Log("Stay");
    }
}
