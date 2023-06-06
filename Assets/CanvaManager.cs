using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaManager : MonoBehaviour
{
    private CameraControls camera;

    void Start()
    {
        camera = FindObjectOfType<CameraControls>(); 
    }

    public void MoveCamera(int dir)
    {
        if (dir == 1)
        {
            camera.MoveCameraRight();
        }
        else
        {
            camera.MoveCameraLeft();
        }
    }

    public void SetMoving(bool moving)
    {
        camera.SetMoving(moving);
    }
}
