using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;

    [SerializeField] protected float range = 500;
    [SerializeField] protected float tracking = 0.05f;
    [SerializeField] protected float maxVelocity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = this.GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().color = Color.green;
        m_rigidbody2D.velocity = transform.up * maxVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(enemies.Length);
        GameObject closest = null;
        foreach (GameObject enemy in enemies)
        {
            Vector2 vectorToEnemy = enemy.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, vectorToEnemy);
            Debug.DrawRay(transform.position, vectorToEnemy);
            Debug.Log(hit.collider.name);

            if (hit && hit.collider.gameObject.Equals(enemy)) // In line of sight
            {
                float distance = Vector3.Distance(enemy.transform.position, transform.position);

                if (distance < range && (closest == null || distance < Vector3.Distance(closest.transform.position, transform.position)))
                {
                    closest = enemy;
                }
            }
        }

        // Move towards closest enemy
        if (closest != null) m_rigidbody2D.velocity = Vector2.Lerp(m_rigidbody2D.velocity.normalized, closest.transform.position - transform.position, tracking);

        // Check max velocity
        m_rigidbody2D.velocity = m_rigidbody2D.velocity.normalized * Mathf.Max(m_rigidbody2D.velocity.magnitude, maxVelocity);
    }
}
