﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private PlayerRotation m_playerRotation;

    [SerializeField] protected float cooldown = 1f;
    [SerializeField] protected float maxSpeed = 5f;
    [SerializeField] protected float minSpeed = 1.5f;
    [SerializeField] protected Rigidbody projectile;
    [SerializeField] protected string[] traits;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        m_playerRotation = this.GetComponent<PlayerRotation>();
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cooldown && m_playerRotation.aiming)
        {
            Rigidbody bullet = Instantiate(projectile, transform.position, transform.rotation);
            foreach (string trait in traits)
            {
                bullet.gameObject.AddComponent(System.Type.GetType(trait));
            }

            bullet.velocity = transform.forward * maxSpeed; // Temporary speed setter
            timer = 0;
        }
    }

    public float getMaxSpeed()
    {
        return maxSpeed;
    }

    public float getMinSpeed()
    {
        return minSpeed;
    }
}
