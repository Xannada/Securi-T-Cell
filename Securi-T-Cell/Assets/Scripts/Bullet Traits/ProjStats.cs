using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjStats : MonoBehaviour
{
    float damage = 1f;
    private float minSpeed;
    private Rigidbody m_rigidbody;
    [SerializeField] protected float aimAssistRange = 10f;

    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        minSpeed = FindObjectOfType<PlayerShooting>().getMinSpeed();

        //aim assist
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = new Vector3(
        mousePosition.x - transform.position.x, 0,
        mousePosition.z - transform.position.z
        );

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = 0;
        float closestDistance = 0;
        foreach (GameObject enemy in enemies)
        {
            distance = Vector3.Distance(enemy.transform.position, mousePosition);
            
            if (distance <= aimAssistRange)
            {
                Debug.Log("distance: " + distance);
                if (closest == null) {
                    closest = enemy;
                    closestDistance = distance;
                }
                else
                {
                    if (distance < closestDistance)
                    {
                        closest = enemy;
                        closestDistance = distance;
                    }
                }
            }
        }
        if (closest != null)
        {
            transform.forward = (closest.transform.position - transform.position).normalized;
            m_rigidbody.velocity = transform.forward * m_rigidbody.velocity.magnitude;
        }
        //End aim assist
        if (Vector3.Dot(m_rigidbody.velocity, FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody>().velocity) > 0)
        {
            m_rigidbody.velocity = m_rigidbody.velocity.normalized * minSpeed  + FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody>().velocity * 1.1f;
        }
        else
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
        else if (!(other.CompareTag("Player") || other.CompareTag("Projectile") || other.CompareTag("Current") || other.CompareTag("Nexus") || other.CompareTag("Ally"))) 
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
