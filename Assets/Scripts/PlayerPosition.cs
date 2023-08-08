using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPosition : MonoBehaviour
{
    public Transform barDoor;
    public Transform houseDoor;
    public GameObject player;

    void Start()
    {
        if (SceneObserver.playerData.currentScene.Contains("House"))
        {
            player.transform.position = houseDoor.position;
        }
        else if (SceneObserver.playerData.currentScene.Contains("Bar"))
        {
            player.transform.position = barDoor.position;
        }

        SceneObserver.playerData.currentScene = SceneManager.GetActiveScene().name;
        SceneObserver.SaveGame();
    }
}
