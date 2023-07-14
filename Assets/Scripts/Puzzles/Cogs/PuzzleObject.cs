using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : ClickManager
{
    public string key;
    public GameObject puzzleCanvas;
    public bool completed;
    public string puzzleName;
    public GameObject objToSpawn;

    void Start()
    {
        completed = SceneObserver.playerData.PuzzleHasCompleted(key);
    }
    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        movementSO.initialPosition = Player.position;
        if (!interrupted && !completed)
        {
            GameObject canvasInstance = Instantiate(puzzleCanvas, gameObject.transform.position, Quaternion.identity);
            if (canvasInstance.GetComponent<CogsManager>() != null)
            {
                canvasInstance.GetComponent<CogsManager>().puzzleName = puzzleName;
            }
            else if (canvasInstance.GetComponent<BarPuzzle>() != null)
            {
                canvasInstance.GetComponent<BarPuzzle>().RecipeObject = objToSpawn;
            }
            SceneObserver.puzzleEvents[puzzleName].AddListener(Complete);
        }
        interrupted = false;
    }

    public void Complete()
    {
        completed = true;
        SceneObserver.playerData.CompletedPuzzles(key);
        SceneObserver.SaveGame();
    }
}
