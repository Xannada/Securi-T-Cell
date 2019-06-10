using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarging : MonoBehaviour
{
    private Vector3 targetScale;

    // Start is called before the first frame update
    void Start()
    {
        targetScale = transform.localScale * 1.75f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.magnitude < targetScale.magnitude)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targetScale = transform.localScale; //Stops growing when it hits an enemy
        }
        
    }
}
