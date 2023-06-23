using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class SceneObserver
{
    public static Dictionary<string, bool> collectedItens = new Dictionary<string, bool>();
    public static Dictionary<string, bool> triggeredCutscenes = new Dictionary<string, bool>();
    public static Dictionary<string, bool> completedPuzzles = new Dictionary<string, bool>();
    public static Dictionary<string, UnityEvent> puzzleEvents = new Dictionary<string, UnityEvent>()
    {
        {"ChestPuzzle", new UnityEvent()}
    };

    public static void InvokeEvent(string eventName)
    {
        if (puzzleEvents.ContainsKey(eventName))
        {
            puzzleEvents[eventName]?.Invoke();
        }
    }

    public static void CollectItem(string key)
    {
        if (!HasItem(key))
        {
            collectedItens.Add(key, true);
        }
    }

    public static bool HasItem(string key)
    {
        return collectedItens.ContainsKey(key);
    }
    public static void TriggerCutscene(string key)
    {
        if (!HasTriggered(key))
        {
            triggeredCutscenes.Add(key, true);
        }
    }

    public static bool HasTriggered(string key)
    {
        return triggeredCutscenes.ContainsKey(key);
    }

    public static void CompletedPuzzles(string key)
    {
        if (!PuzzleHasCompleted(key))
        {
            completedPuzzles.Add(key, true);
        }
    }

    public static bool PuzzleHasCompleted(string key)
    {
        return completedPuzzles.ContainsKey(key);
    }

}
