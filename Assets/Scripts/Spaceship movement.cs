using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceshipmovement : MonoBehaviour
{
    private Transform m_Transform;
    Vector3 direction;
    float speed = 0f;
    float speedLimit = 100f;
    float acceleration = 0f;
    float attenuation = 0.01f;
    Vector3 rotationAngle;

    void Start()
    {
        m_Transform = GetComponent<Transform>();
        direction = m_Transform.right;
        rotationAngle.Set(0f, 0f, 0.05f);
    }

    void FixedUpdate()
    {
        acceleration = Input.GetKey(KeyCode.W) ? 0.1f : 0f;
        direction = Input.GetKey(KeyCode.A) ? Quaternion.Euler(0, -3, 0) * direction : direction;
        direction = Input.GetKey(KeyCode.D) ? Quaternion.Euler(0, 3, 0) * direction : direction;
        direction = Vector3.Normalize(direction);

        speed += acceleration / (speed + 0.1f);
        speed = speed > speedLimit ? speedLimit : speed;

        m_Transform.position += direction * speed * Time.deltaTime;

        if (speed >= attenuation)
        {
            speed -= attenuation;
        }
    }
}
