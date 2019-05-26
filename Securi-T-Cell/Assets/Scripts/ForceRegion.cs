using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceRegion : MonoBehaviour
{
    [SerializeField] protected float force_Strength;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        
        rb.AddForce(transform.up * force_Strength);
        
        
        //Debug.Log("Stay");
    }
}
