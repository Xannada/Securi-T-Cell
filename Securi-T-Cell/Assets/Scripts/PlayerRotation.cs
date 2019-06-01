using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Vector3 input_direction;
    public bool aiming { get; private set; } = false;

    // Update is called once per frame
    void Update()
    {
        aiming = false;
        if (Input.GetMouseButton(0)) faceMouse();
        faceAxis();
    }

    void faceMouse()
    {
        if (Time.timeScale == 1f)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 direction = new Vector3(
                mousePosition.x - transform.position.x, 0,
                mousePosition.z - transform.position.z
                );
            
            transform.forward = direction;
            aiming = true;
        }
    }

    void faceAxis()
    {
        input_direction = new Vector3(Input.GetAxisRaw("Horizontal2"), 0, Input.GetAxisRaw("Vertical2"));

        if (input_direction != Vector3.zero)
        {
            transform.forward = input_direction;
            aiming = true;
        }
    }
}
