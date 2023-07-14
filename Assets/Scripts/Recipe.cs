using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recipe : ClickManager
{
    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        movementSO.initialPosition = Player.position;
        if (!interrupted)
        {
            SceneManager.LoadScene("GoodEnding");
        }
        interrupted = false;
    }
}
