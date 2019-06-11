using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarging : MonoBehaviour
{
    public float targetScale = 1.75f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.magnitude < targetScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale * Vector3.one, Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targetScale = transform.localScale.magnitude; //Stops growing when it hits an enemy
        }
        
    }
}
