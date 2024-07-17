using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpaceshipMovement : MonoBehaviour
{
    public float speed = 0;
    public float rotationSpd = 0.5f;
    public float currentSpd = 0;

    public float acceleration = 3f;
    public float deceleration = 1.5f;

    public float minSpeed = 0;
    public float maxSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Forward();
        }

        if (Input.GetKey(KeyCode.A))
        {
            Steer(1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Steer(-1);
        }

        Decelerate();
    }

    public void Forward()
    {
        speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        float translation = speed * Time.deltaTime;
        transform.Translate(0, translation, 0);
        currentSpd = translation;
    }

    public void Steer(int steerValue)
    {
        float rotation = rotationSpd;
        if (steerValue == 1)
        {
            transform.Rotate(0, 0, rotation);
        }
        else if (steerValue == -1)
        {
            transform.Rotate(0, 0, -rotation);
        }
    }

    public void Decelerate()
    {
        speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        float translation = speed * Time.deltaTime;
        transform.Translate(0, translation, 0);
        currentSpd = translation;
    }
}
