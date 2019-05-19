using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Vector2 input_direction;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) faceMouse();
        faceAxis();
    }

    void faceMouse()
    {
        if (Time.timeScale == 1f)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 direction = new Vector2(
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y
                );

            transform.up = direction;
        }
    }

    void faceAxis()
    {
        input_direction = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
        if (input_direction != Vector2.zero) transform.up = input_direction;
    }
}
