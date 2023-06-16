using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerArrows : MonoBehaviour
{
    [SerializeField] private ClickManager floor;
    [SerializeField] private MovementSO movementSO;
    private float speed;
    private float run;
    private float currentSpeed;
    private int modex = 0;
    private int modey = 0;
    private bool moving = false;

    private void Start()
    {
        run = movementSO.runSpeed;
        speed = movementSO.moveSpeed;
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving && movementSO.canMove)
        {
            transform.position += new Vector3((modex * currentSpeed) * Time.deltaTime, (modey * currentSpeed) * Time.deltaTime, 0);
            floor.movementSO.redirect = false;
            floor.movementSO.initialPosition = this.transform.position;
        }
    }

    public void OnRun(InputAction.CallbackContext ctx)
    {
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
        Vector2 moveVec = ctx.ReadValue<Vector2>();

        if (moveVec != Vector2.zero)
            moving = true;
        else
            moving = false;

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

