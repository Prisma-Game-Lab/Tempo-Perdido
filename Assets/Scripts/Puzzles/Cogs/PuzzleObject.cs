using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : ClickManager
{
    [SerializeField] private GameObject puzzleCanvas;
    // Start is called before the first frame update
    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        movementSO.initialPosition = Player.position;
        if (!interrupted)
        {
            Instantiate(puzzleCanvas, gameObject.transform.position, Quaternion.identity);
        }
        interrupted = false;
    }
}
