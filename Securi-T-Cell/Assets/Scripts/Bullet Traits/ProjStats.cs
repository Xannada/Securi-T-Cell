using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjStats : MonoBehaviour
{
    private Rigidbody m_rigidbody;


    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStats>().Damage(PlayerStats.player.damage);
            GameObject wound = Instantiate(gameObject, other.transform, true);
            foreach (MonoBehaviour mb in wound.GetComponents<MonoBehaviour>()) mb.enabled = false;
            wound.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(wound.GetComponent<ProjStats>());
            Destroy(gameObject);
        }
        else if (!(other.CompareTag("Player") || other.CompareTag("Projectile") || other.CompareTag("Current") || other.CompareTag("Nexus") || other.CompareTag("Ally"))) 
        {   
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            other.collider.GetComponent<EnemyStats>().Damage(PlayerStats.player.damage);
            GameObject wound = Instantiate(gameObject, other.transform, true);
            foreach (MonoBehaviour mb in wound.GetComponents<MonoBehaviour>()) mb.enabled = false;
            wound.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(wound.GetComponent<ProjStats>());
            Destroy(gameObject);
        }
    }
}
