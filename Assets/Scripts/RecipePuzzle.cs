using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipePuzzle : ClickManager
{
    public PuzzleObject obj;
    public GameObject barPuzzleCanvas;

    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        movementSO.initialPosition = Player.position;

        if (!interrupted && obj.completed)
        {
            obj.puzzleCanvas = barPuzzleCanvas;
            obj.completed = false;
            obj.key = "BarPuzzle";
            obj.puzzleName = "BarPuzzle";
            this.enabled = false;
        }

        interrupted = false;
    }
}
