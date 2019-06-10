using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitting : MonoBehaviour
{
    public float splitDelay = 1;
    private float timer = 0;
    public float splitAngle = 30;
    public float splitCount = 4;
    public float speed;

    // Start is called before the first frame update
    private void Start()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > splitDelay)
        {
            if (splitCount == 0) return;
            if (splitCount % 2 == 1)
            {
                Destroy(gameObject);
                GameObject projectile = Instantiate(gameObject, transform.position, transform.rotation * Quaternion.Euler(0, splitAngle / 2, 0));
                projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * speed;
                projectile.GetComponent<Splitting>().enabled = false;
                projectile = Instantiate(gameObject, transform.position, transform.rotation * Quaternion.Euler(0, splitAngle / -2, 0));
                projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * speed;
                projectile.GetComponent<Splitting>().enabled = false;
                for (int i = 2; i <= splitCount; i++)
                {
                    projectile = Instantiate(gameObject, transform.position, transform.rotation * Quaternion.Euler(0, (splitAngle / 2  + splitAngle * (i / 2)) * Mathf.Pow(-1, i), 0));
                    projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * speed;
                    projectile.GetComponent<Splitting>().enabled = false;
                }
            }
            else
            {
                for (int i = 2; i <= splitCount + 1; i++)
                { 
                    GameObject projectile = Instantiate(gameObject, transform.position, transform.rotation * Quaternion.Euler(0, splitAngle * (i / 2) * Mathf.Pow(-1, i), 0));
                    projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * speed;
                    projectile.GetComponent<Splitting>().enabled = false;
                }
            }

            this.enabled = false;
        }
    }
}
