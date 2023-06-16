using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PuzzleSO", menuName = "ScriptableObjects/Puzzle")]
public class PuzzleSO : ScriptableObject
{
    public SerializableDictionary<string, UnityEvent> puzzleEvents = new SerializableDictionary<string, UnityEvent>();

    private void OnEnable()
    {
        puzzleEvents.Clear();
        puzzleEvents.Add("ChestPuzzle", new UnityEvent());
    }

    public void InvokeEvent(string eventName)
    {
        if (puzzleEvents.ContainsKey(eventName))
        {
            puzzleEvents[eventName]?.Invoke();
        }
    }

}
