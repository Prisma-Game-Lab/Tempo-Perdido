using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerArrows : MonoBehaviour
{
    public float speed = 0.2f;
    public float run = 0.4f;
    private float currentSpeed;
    private int modex = 0;
    private int modey = 0;

    private void Star()
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(currentSpeed * Time.deltaTime * modex, currentSpeed * Time.deltaTime * modey, 0);
    }

    public void OnRun (InputAction.CallbackContext ctx)
    {
        Debug.Log("Run");
        if (ctx.performed)
        {
            currentSpeed = run;
            

        }

        else if (ctx.canceled)
        {
            currentSpeed = speed;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Debug.Log("Move");
        Vector2 moveVec = ctx.ReadValue<Vector2>();

        if (moveVec.x > 0)
        {
            modex = 1;
        }
        else if (moveVec.x < 0)
        {
            modex = -1;
        }
        else
        {
            modex = 0;
        }

        if (moveVec.y > 0)
        {
            modey = 1;
        }
        else if (moveVec.y < 0)
        {
            modey = -1;
        }
        else
        {
            modey = 0;
        }
    }
}

