using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBCNexus : MonoBehaviour
{
    public List<RBCNexus> possibleExits;


    private RBCNexus GiveNextPath()
    {
        int ranValue = Random.Range(0, possibleExits.Count);

        return possibleExits[ranValue];
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.CompareTag("Ally"))
        {
            RBCPathing RBC = col.transform.GetComponent<RBCPathing>();
            if (RBC)
            {
                RBC.SetTarget(GiveNextPath());
            }
        }
    }
}
