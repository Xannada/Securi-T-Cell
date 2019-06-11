using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public static PlayerStats player { get; private set; }

    [SerializeField] private float _health = 10;
    [SerializeField] private float _damage = 1;
    [SerializeField] private float _fireRate = 1;
    [SerializeField] private float _speed = 20;
    [SerializeField] private string[] _traits;
    
    public float health { get => _health; private set => _health = value; }
    public float damage { get => _damage; private set => _damage = value; }
    public float fireRate { get => _fireRate; private set => _fireRate = value; }
    public float speed { get => _speed; private set => _speed = value; }
    public string[] traits { get => _traits; private set => _traits = value; }

    private float initHealth;

    private void Awake()
    {
        if (player) Destroy(gameObject);
        else player = this;
    }

    private void Start()
    {
        initHealth = health;
    }

    public void Damage(float damage)
    {
        if (health > damage)
            health -= damage;
        else
        {
            Reset();
        }
    }

    public void Heal(float amount)
    {
        if (health + amount <= initHealth)
            health += amount;
    }

    private void Reset()
    {
        GameObject [] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject farthestNexus = null;
        float farthestDistance = -1;

        foreach (GameObject nexus in GameObject.FindGameObjectsWithTag("Nexus"))
        {
            if (nexus)
            {
               GameObject closestEnemy = null;
                float closestDistance = 0;
                bool success = true;

                foreach (GameObject enemy in enemies)
                {
                    if (enemy)
                    {
                        float distance = Vector3.Distance(nexus.transform.position, enemy.transform.position);
                        if (farthestDistance != -1 && distance < farthestDistance)
                        {
                            success = false;
                            break;
                        }
                        if (!closestEnemy || distance < closestDistance)
                        {
                            closestEnemy = enemy;
                            closestDistance = distance;
                        }
                    }
                }

                if (!farthestNexus || success)
                {
                    farthestNexus = nexus;
                    farthestDistance = closestDistance;
                }
            }
        }

        if (farthestNexus) transform.position = farthestNexus.transform.position;
        else transform.position = Vector3.zero;

        health = initHealth;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
