using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D m_rigidbody2D;
    [SerializeField] protected float player_speed;
    [SerializeField] protected float direction_responsiveness;
    [SerializeField] protected float stopping_responsiveness;
    [SerializeField] protected float response_offset; //Should always be set higher than 1
    private Vector2 input_direction;

    void Start()
    {
        m_rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input_direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
            input_direction += new Vector2(0, 1);
        if (Input.GetKey(KeyCode.S))
            input_direction += new Vector2(0, -1);
        if (Input.GetKey(KeyCode.D))
            input_direction += new Vector2(1, 0);
        if (Input.GetKey(KeyCode.A))
            input_direction += new Vector2(-1, 0);
        Vector3 current_direction = m_rigidbody2D.velocity;
        current_direction.Normalize();
        input_direction.Normalize();
        if (input_direction != Vector2.zero)
        {
            //Creates a value between -1 and 1, plus the response offset, higher values will result when the input direction is closer to the current direction
            float direction_change = Vector3.Dot(input_direction, current_direction) + response_offset; 
            //Using lerp so change in velocity is not instantaneous, using the direction_change and direction_responsiveness to determine
            //how close to the desired direction the player will actually move. Harder to change directions/move against your current momentum.
            m_rigidbody2D.velocity = Vector3.Lerp(m_rigidbody2D.velocity, input_direction * player_speed, direction_change * direction_responsiveness * Time.deltaTime);
        }
        else
        {
      
            m_rigidbody2D.velocity = Vector3.Lerp(m_rigidbody2D.velocity, input_direction * player_speed, stopping_responsiveness * Time.deltaTime);
        }
  

    }
}
