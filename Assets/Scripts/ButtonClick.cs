using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public void Click()
    {
        AudioManager.instance.PlaySfx("ClickButton");
    }

    public void StartGame()
    {
        AudioManager.instance.PlaySfx("GameStart");
    }
}
