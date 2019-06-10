using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainSpeed : MonoBehaviour
{
    private float maxVelocity;
    private Rigidbody m_rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        maxVelocity = FindObjectOfType<PlayerShooting>().getProjSpeed();   
    }

    // Update is called once per frame
    void Update()
    {
        if (m_rigidbody.velocity.magnitude < maxVelocity)
            m_rigidbody.velocity = Vector3.Lerp(m_rigidbody.velocity, m_rigidbody.velocity.normalized * maxVelocity, Time.deltaTime);
    }
}
