using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    private PlayerRotation m_playerRotation;

    [SerializeField] protected float cooldown = 1;
    [SerializeField] protected Rigidbody2D projectile;
    [SerializeField] protected string[] traits;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = this.GetComponent<Rigidbody2D>();
        m_playerRotation = this.GetComponent<PlayerRotation>();
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cooldown && m_playerRotation.aiming)
        {
            Rigidbody2D bullet = Instantiate(projectile, transform.position, transform.rotation);
            foreach (string trait in traits)
            {
                bullet.gameObject.AddComponent(System.Type.GetType(trait));
            }

            bullet.velocity = transform.up; // Temporary speed setter
            timer = 0;
        }
    }
}
