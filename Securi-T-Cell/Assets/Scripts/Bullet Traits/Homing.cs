using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    [SerializeField] protected float range = 500;
    [SerializeField] protected float tracking = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        //GetComponent<SpriteRenderer>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        foreach (GameObject enemy in enemies)
        {
            Vector3 vectorToEnemy = enemy.transform.position - transform.position;
            RaycastHit hit; 
            bool didhit = Physics.Raycast(transform.position, vectorToEnemy, out hit);
  //          Debug.DrawRay(transform.position, vectorToEnemy);
//            Debug.Log(hit.collider.name);

            if (didhit && hit.collider.gameObject.Equals(enemy)) // In line of sight
            {
                float distance = Vector3.Distance(enemy.transform.position, transform.position);

                if (distance < range && (closest == null || distance < Vector3.Distance(closest.transform.position, transform.position)))
                {
                    closest = enemy;
                }
            }
        }

        // Move towards closest enemy
        if (closest != null)
        {
            transform.forward = Vector3.Lerp(m_rigidbody.velocity.normalized, (closest.transform.position - transform.position).normalized, tracking).normalized;
            m_rigidbody.velocity = transform.forward * m_rigidbody.velocity.magnitude;
        }
    }
}
