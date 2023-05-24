using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerArrows : MonoBehaviour
{
    public float speed = 0.2f;
    public float run = 0.4f;

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed = run;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(currentSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-currentSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, currentSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -currentSpeed * Time.deltaTime, 0);
        }
    }
}
