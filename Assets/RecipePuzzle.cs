using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipePuzzle : ClickManager
{
    public PuzzleObject obj;
    public GameObject RecipeObject;

    void OnEnable()
    {
        SceneObserver.puzzleEvents["RecipePuzzle"].AddListener(SpawnRecipe);
    }

    void OnDesable()
    {
        SceneObserver.puzzleEvents["RecipePuzzle"].RemoveListener(SpawnRecipe);
    }

    public void SpawnRecipe()
    {
        RecipeObject.SetActive(true);
    }

    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        movementSO.initialPosition = Player.position;
        
        if (!interrupted && obj.completed)
        {
            SceneObserver.InvokeEvent(obj.puzzleName);
        }

        interrupted = false;
    }
}
