using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public int steerValue;
    private int direction;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))    // forward
        {
            direction = 1;
            this.GetComponent<CarMovement>().Forward();
            CheckIfSteering();
        }
        else if (Input.GetKey(KeyCode.S))   // reverse
        {
            direction = -1;
            this.GetComponent<CarMovement>().Reverse();
            CheckIfSteering();
        }
        else if (!Input.GetKey(KeyCode.W) && direction == 1)
        {
            this.GetComponent<CarMovement>().Decelerate();
            CheckIfSteering();
        }
        else if (!Input.GetKey(KeyCode.S) && direction == -1)
        {
            this.GetComponent<CarMovement>().DecelerateReverse();
            CheckIfSteering();
        }
    }

    public void CheckIfSteering()
    {
        if (Input.GetKey(KeyCode.A) && direction == 1)    // forward left
        {
            steerValue = -1;
            this.GetComponent<CarMovement>().Steer(steerValue, direction);
        }
        else if (Input.GetKey(KeyCode.D) && direction == 1)   // forward right
        {
            steerValue = 1;
            this.GetComponent<CarMovement>().Steer(steerValue, direction);
        }
        else if (Input.GetKey(KeyCode.A) && direction == -1)    // reverse left
        {
            steerValue = -1;
            this.GetComponent<CarMovement>().Steer(steerValue, direction);
        }
        else if (Input.GetKey(KeyCode.D) && direction == -1)   // forward right
        {
            steerValue = 1;
            this.GetComponent<CarMovement>().Steer(steerValue, direction);
        }
        else
        {
            this.GetComponent<CarMovement>().Steer(steerValue, direction);
            StartCoroutine(ResetSteering());
        }
    }

    IEnumerator ResetSteering()
    {
        float timer = 1.0f;

        while (timer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timer--;
        }
        steerValue = 0;
    }
}
