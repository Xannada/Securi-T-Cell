using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjStats : MonoBehaviour
{
    float damage = 1f;

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
        else if (!(other.CompareTag("Player") || other.CompareTag("Projectile"))) 
        {   
            Destroy(gameObject);
        }
    }
}
