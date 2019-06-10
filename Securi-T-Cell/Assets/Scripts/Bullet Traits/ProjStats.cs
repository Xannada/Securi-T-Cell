﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjStats : MonoBehaviour
{
    float damage = 1f;
    private float minSpeed;
    private Rigidbody m_rigidbody;

    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        minSpeed = FindObjectOfType<PlayerShooting>().getMinSpeed();
    }
    private void Update()
    {
        if (m_rigidbody.velocity.magnitude < minSpeed)
        {
            m_rigidbody.velocity = m_rigidbody.velocity.normalized * minSpeed;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStats>().Damage(damage);
            GameObject wound = Instantiate(gameObject, other.transform, true);
            wound.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(wound.GetComponent<ProjStats>());
            Destroy(gameObject);
        }
        else if (!(other.CompareTag("Player") || other.CompareTag("Projectile") || other.CompareTag("Current") || other.CompareTag("Nexus"))) 
        {   
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            other.collider.GetComponent<EnemyStats>().Damage(damage);
            GameObject wound = Instantiate(gameObject, other.transform, true);
            foreach (MonoBehaviour mb in wound.GetComponents<MonoBehaviour>()) mb.enabled = false;
            wound.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(wound.GetComponent<ProjStats>());
            Destroy(gameObject);
        }
    }
}
