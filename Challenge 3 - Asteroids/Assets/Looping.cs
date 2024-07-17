using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looping : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 viewport = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 loopAround = Vector3.zero;

        if (viewport.x < 0)
        {
            loopAround.x += 1;
        }
        else if (viewport.x > 1)
        {
            loopAround.x -= 1;
        }
        else if (viewport.y < 0)
        {
            loopAround.y += 1;
        }
        else if (viewport.y > 1)
        {
            loopAround.y -= 1;
        }

        transform.position = Camera.main.ViewportToWorldPoint(viewport + loopAround);
    }
}
