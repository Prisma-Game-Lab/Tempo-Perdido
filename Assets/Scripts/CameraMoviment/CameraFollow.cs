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

    private bool canFollow;

    void Start()
    {
        Vector3 targetPosition = new Vector3(Player.transform.position.x, minYFloor, -10);
        transform.position = targetPosition;
    }

    private void LateUpdate()
    {
        CheckPlayerPosition();

        if (cameraLocked && canFollow)
        {
            Vector3 targetPosition = Player.TransformPoint(new Vector3(0, 0, -10));
            targetPosition.y = minYFloor;

            float clampoffset = Mathf.Clamp(transform.position.x, minXWall, maxXWall);
            Vector3 newPosition = new Vector3(clampoffset, transform.position.y, transform.position.z);

            transform.position = Vector3.SmoothDamp(newPosition, targetPosition, ref velocity, cameraMoveSpeed);
        }
    }

    private void CheckPlayerPosition()
    {
        if (Player.transform.position.x >= minXWall && Player.transform.position.x <= maxXWall)
        {
            canFollow = true;
        }
        else
        {
            canFollow = false;
        }
    }
}