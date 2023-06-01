using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player;
    public float minXWall, maxXWall, minYFloor;
    public float timeLerp;
        
    private void FixedUpdate()
    {
        Vector3 newPosition = Player.position + new Vector3(0, 0, -10);
        newPosition.y = minYFloor;
        newPosition = Vector3.Lerp(transform.position, newPosition, timeLerp);
        transform.position = newPosition;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minXWall,maxXWall),transform.position.y, transform.position.z);
    }
}
