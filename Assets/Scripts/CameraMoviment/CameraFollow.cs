using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float minXWall, maxXWall, minYFloor;
    public float cameraMoveSpeed;
    public bool cameraLocked = true;
    public Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (cameraLocked)
        {
            Vector3 targetPosition = Player.TransformPoint(new Vector3(0, 0, -10));
            targetPosition.y = minYFloor;

            float clampoffset = Mathf.Clamp(transform.position.x, minXWall, maxXWall);
            Vector3 newPosition = new Vector3(clampoffset, transform.position.y, transform.position.z);

            transform.position = Vector3.SmoothDamp(newPosition,targetPosition,ref velocity,cameraMoveSpeed);
        }
    }
}