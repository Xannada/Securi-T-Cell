using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainSpeed : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        speed = m_rigidbody.velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_rigidbody.velocity.magnitude != speed)
            m_rigidbody.velocity = Vector3.Lerp(m_rigidbody.velocity, m_rigidbody.velocity.normalized * speed, .5f * Time.deltaTime);
    }
}
