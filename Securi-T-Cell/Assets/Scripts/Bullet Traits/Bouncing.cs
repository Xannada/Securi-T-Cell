using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private Rigidbody m_player;
    [SerializeField] protected float projectileLife = 15f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SphereCollider>().isTrigger = false; 
        Destroy(gameObject, projectileLife);
    }
}
