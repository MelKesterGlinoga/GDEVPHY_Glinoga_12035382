using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 0;
    public float rotationSpd = 0.01f;
    public float currentSpd = 0;

    public float acceleration = 5f;
    public float deceleration = 5f;

    public float minSpeed = 0;
    public float maxSpeed = 15f;

    public void Forward()
    {
        speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        float translation = speed * Time.deltaTime;
        transform.Translate(0, 0, translation);
        currentSpd = translation;
    }

    public void Reverse()
    {
        speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        float translation = speed * Time.deltaTime;
        transform.Translate(0, 0, -translation);
        currentSpd = translation;
    }

    public void Steer(int steerValue, int direction)
    {
        // only turn if accelerating
        float rotation = rotationSpd * speed;
        if (currentSpd > 0 && steerValue == 1 && direction == 1)    // direction = 1 == forward
        {
            transform.Rotate(0, rotation, 0);
        }
        else if (currentSpd > 0 && steerValue == -1 && direction == 1)
        {
            transform.Rotate(0, -rotation, 0);
        }
        else if (currentSpd > 0 && steerValue == 1 && direction == -1)  // direction = -1 == reverse
        {
            transform.Rotate(0, -rotation, 0);
        }
        else if (currentSpd > 0 && steerValue == -1 && direction == -1)
        {
            transform.Rotate(0, rotation, 0);
        }
    }

    public void Decelerate()
    {
        speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        float translation = speed * Time.deltaTime;
        transform.Translate(0, 0, translation);
        currentSpd = translation;
    }

    public void DecelerateReverse()
    {
        speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        float translation = speed * Time.deltaTime;
        transform.Translate(0, 0, -translation);
        currentSpd = translation;
    }
}