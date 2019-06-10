using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private Rigidbody m_player;
    [SerializeField] protected float maxVelocity = 10f;
    [SerializeField] protected float projectileLife = 15f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        m_player = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Rigidbody>();
        m_rigidbody.velocity = m_player.transform.forward * maxVelocity + m_player.velocity;
        maxVelocity = Mathf.Max(maxVelocity, m_rigidbody.velocity.magnitude);
        gameObject.GetComponent<SphereCollider>().isTrigger = false; 
        Destroy(gameObject, projectileLife);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_rigidbody.velocity.magnitude < maxVelocity)
            m_rigidbody.velocity = Vector3.Lerp(m_rigidbody.velocity, m_rigidbody.velocity.normalized * maxVelocity, Time.deltaTime);
    }
}
