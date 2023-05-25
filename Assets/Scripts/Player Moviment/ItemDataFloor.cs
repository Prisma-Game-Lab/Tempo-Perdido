using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemDataFloor : ClickManager
{
    public float heigh = 1f;

    public void SetGoToPoint(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            mousePosition.z = Camera.main.transform.position.z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            worldPosition.z = itemData.goToPoint.position.z + heigh;
            itemData.goToPoint.position = worldPosition;
        }
    }

    public override void Interact()
    {
        base.Interact();
    }
}

