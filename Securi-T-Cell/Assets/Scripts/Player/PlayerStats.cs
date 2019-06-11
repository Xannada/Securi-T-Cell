using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats player { get; private set; }

    [Header("Current Stats")]
    [SerializeField] private float _health = 10;
    [SerializeField] private float _damage = 1;
    [SerializeField] private float _fireRate = 1;
    [SerializeField] private float _speed = 20;
    [SerializeField] private List<string> _traits; //unique list 

    [Header("Levels")]
    [SerializeField] private float _healthLevel= 1;
    [SerializeField] private float _damageLevel = 1;
    [SerializeField] private float _fireRateLevel = 1;
    [SerializeField] private float _speedLevel = 1;

    [Header("Upgrade Amounts")]
    [SerializeField] private float _healthIncrease = 5;
    [SerializeField] private float _damageIncrease = 1;
    [SerializeField] private float _fireRateIncrease = 1;   
    [SerializeField] private float _speedIncrease = 5;

    public float health { get => _health; private set => _health = value; }
    public float damage { get => _damage; private set => _damage = value; }
    public float fireRate { get => _fireRate; private set => _fireRate = value; }
    public float speed { get => _speed; private set => _speed = value; }
    public List<string> traits { get => _traits; private set => _traits = value; }

    public float healthLevel { get => _healthLevel; private set => _healthLevel = value; }
    public float damageLevel { get => _damageLevel; private set => _damageLevel = value; }
    public float fireRateLevel { get => _fireRateLevel; private set => _fireRateLevel = value; }
    public float speedLevel { get => _speedLevel; private set => _speedLevel = value; }

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

    public bool hasTrait(string trait)
    {
        return traits.Contains(trait);
    }

    public void addTrait(string trait)
    {
        traits.Add(trait);
    }

    public void upgradeHealth()
    {
        health += _healthIncrease;
        initHealth += _healthIncrease;
        healthLevel++;
    }

    public void upgradeDamage()
    {
        damage += _damageIncrease;
        damageLevel++;
    }

    public void upgradeFirerate()
    {
        fireRate += _fireRateIncrease;
        fireRate++;
    }

    public void upgradeSpeed()
    {
        speed += _speedIncrease;
        speedLevel++;
    }
}
