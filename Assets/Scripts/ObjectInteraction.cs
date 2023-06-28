using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectInteraction : MonoBehaviour
{
    private bool canInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
            Debug.Log("ENTER");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
            Debug.Log("EXIT");
        }
    }

    public void Interact(InputAction.CallbackContext ctx) 
    { 
        if (ctx.performed && canInteract)
        {
            GetComponent<ClickManager>().Interact();
        }
    }
}
