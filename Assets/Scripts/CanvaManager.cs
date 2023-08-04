using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvaManager : MonoBehaviour
{
    private CameraControls camera;

    void Start()
    {
        AudioManager.instance.StopAllSounds();
        if (SceneManager.GetActiveScene().name.Contains("Bar"))
        {
            AudioManager.instance.PlaySound("ThePub");
            AudioManager.instance.PlaySfx("AmbiencePub");
        }
        else if (SceneManager.GetActiveScene().name.Contains("House"))
        {
            AudioManager.instance.PlaySound("FriendHouse");
        }
        else if (SceneManager.GetActiveScene().name.Contains("Menu"))
        {
            AudioManager.instance.PlaySound("Menu");
        }
        else if (SceneManager.GetActiveScene().name.Contains("Game"))
        {
            AudioManager.instance.PlaySound("FriendStreet");
            AudioManager.instance.PlaySfx("AmbienceStreet");
        }
        else if (SceneManager.GetActiveScene().name.Contains("Good"))
        {
            AudioManager.instance.PlaySound("TrueEnding");
        }
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
