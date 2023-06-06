using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public float cameraMoveSpeed;
    private bool moving;
    Vector3 direction;

    private void LateUpdate()
    {       
        if (moving)
        {
            Vector3 targetPosition = transform.TransformPoint(new Vector3(0, 0, -10) + direction);
            targetPosition.y = cameraFollow.minYFloor;

            float clampoffset = Mathf.Clamp(transform.position.x, cameraFollow.minXWall, cameraFollow.maxXWall);
            Vector3 newPosition = new Vector3(clampoffset, transform.position.y, transform.position.z);

            transform.position = Vector3.SmoothDamp(newPosition, targetPosition, ref cameraFollow.velocity, cameraMoveSpeed);
        }
    }

    public void SetMoving(bool value)
    {
        moving = value;
    }

    public void MoveCameraLeft()
    {
        direction = Vector3.left;
        cameraFollow.cameraLocked = false;
        SetMoving(true);    
    }

    public void MoveCameraRight()
    {
        direction = Vector3.right;
        cameraFollow.cameraLocked = false;
        SetMoving(true);

    }

    public void OnReset(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            cameraFollow.cameraLocked = true;
        }
    }
}

