using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health { private set; get; } = 5;

    public bool readyToDie = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Damage(float damage)
    {
        if (health > damage) 
        {
            health -= damage;
        }
        else 
        {
            readyToDie = true;
        }
    }
}
