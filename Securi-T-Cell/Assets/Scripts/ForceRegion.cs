using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceRegion : MonoBehaviour
{
    [SerializeField] protected float force_Strength;

    private void OnTriggerStay(Collider collision)
    {

        ForceRegionAcceptor fRA = collision.gameObject.GetComponent<ForceRegionAcceptor>();

        if (!fRA)
            return;
       
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        
        rb.AddForce(transform.up * force_Strength * fRA.forceRatio);
    }
}
