using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private PlayerRotation m_playerRotation;
    
    [SerializeField] protected Rigidbody projectile;
    [SerializeField] protected float projSpeed = 10;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        m_playerRotation = this.GetComponent<PlayerRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (PlayerStats.player.fireRate != 0 && timer >= 1 / PlayerStats.player.fireRate && m_playerRotation.aiming)
        {
            Rigidbody bullet = Instantiate(projectile, transform.position, transform.rotation);
            foreach (string trait in PlayerStats.player.traits)
            {
                bullet.gameObject.AddComponent(System.Type.GetType(trait));
            }

            bullet.velocity = transform.forward * projSpeed + GetComponent<Rigidbody>().velocity;
            timer = 0;
        }
    }
}
