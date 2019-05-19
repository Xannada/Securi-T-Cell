using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
