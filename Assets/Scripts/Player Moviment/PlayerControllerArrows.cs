using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerArrows : MonoBehaviour
{
    [SerializeField] private ClickManager floor;
    [SerializeField] private MovementSO movementSO;
    [SerializeField] private Collider2D limitObjectCollider;
    [SerializeField] private Animator animator;
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

        // Check if the object is in the limit defined
        if (limitObjectCollider != null)
        {
            Vector3 newPosition = transform.position;

            // Calculate the limit of the 'limit' object 
            var leftBorder = limitObjectCollider.bounds.min.x;
            var rightBorder = limitObjectCollider.bounds.max.x;
            var topBorder = limitObjectCollider.bounds.min.y;
            var bottomBorder = limitObjectCollider.bounds.max.y;

            // Check if the new position is inside the limits of the object 
            newPosition.x = Mathf.Clamp(newPosition.x, leftBorder, rightBorder);
            newPosition.y = Mathf.Clamp(newPosition.y, topBorder, bottomBorder);

            // Update the Player's position 
            transform.position = newPosition;
        }
    }

    public void OnRun(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            AudioManager.instance.StopSfx("Steps1");
            AudioManager.instance.PlaySfx("Run");

            currentSpeed = run;
        }
        else if (ctx.canceled)
        {
            AudioManager.instance.StopSfx("Run");
            currentSpeed = speed;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 moveVec = ctx.ReadValue<Vector2>();

        if (moveVec != Vector2.zero)
        {
            animator.SetBool("walking", true);
            if (currentSpeed != run)
            {
                AudioManager.instance.PlaySfx("Steps1");
            }
            moving = true;
        }
        else
        {
            animator.SetBool("walking", false);
            AudioManager.instance.StopSfx("Steps1");
            AudioManager.instance.StopSfx("Run");
            moving = false;
        }

        if (moveVec.x > 0)
        {
            modex = 1;
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (moveVec.x < 0)
        {
            modex = -1;
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
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

