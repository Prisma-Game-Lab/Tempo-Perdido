using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float minXWall, maxXWall, minYFloor;
    public float cameraMoveSpeed;
    public bool cameraLocked = true;


    private void FixedUpdate()
    {
        if (cameraLocked)
        {
            Vector3 targetPosition = Player.position + new Vector3(0, 0, -10);
            targetPosition.y = minYFloor;

            Vector3 newPosition = transform.position + (targetPosition - transform.position) * cameraMoveSpeed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, minXWall, maxXWall);

            transform.position = newPosition;
        }
    }
}