using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SceneObserver
{
    public static Dictionary<string, UnityEvent> puzzleEvents = new Dictionary<string, UnityEvent>()
    {
        {"ChestPuzzle", new UnityEvent()},
        {"RecipePuzzle", new UnityEvent()},
    };

    public static PlayerData playerData = new PlayerData();

    public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = System.IO.Path.Combine(Application.persistentDataPath, "tictac.save");

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData LoadGame()
    {
        string path = System.IO.Path.Combine(Application.persistentDataPath, "tictac.save");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            playerData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return playerData;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
    }

    public static void InvokeEvent(string eventName)
    {
        if (puzzleEvents.ContainsKey(eventName))
        {
            puzzleEvents[eventName]?.Invoke();
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string currentScene;
    public Dictionary<string, bool> collectedItens = new Dictionary<string, bool>();
    public Dictionary<string, bool> triggeredCutscenes = new Dictionary<string, bool>();
    public Dictionary<string, bool> completedPuzzles = new Dictionary<string, bool>();
    public List<ItemSaveData> inventory = new List<ItemSaveData>();
    public List<int> digits = new List<int>();

    public PlayerData()
    {
        currentScene = "Game_Future";

        for (int i = 0; i < 4; i++)
        {
            digits.Add(Random.Range(0,10));
        }
    }

    public void KeepInventory(List<CollectableObject> items)
    {
        for (int i = 0; i < 8; i++)
        {
            ItemSaveData item = new ItemSaveData();
            item.key = items[i].key;
            item.qtd = items[i].qtd;
            inventory.Add(item);
        }
    }

    public void CollectItem(string key)
    {
        if (!HasItem(key))
        {
            collectedItens.Add(key, true);
        }
    }

    public bool HasItem(string key)
    {
        return collectedItens.ContainsKey(key);
    }

    public void TriggerCutscene(string key)
    {
        if (!HasTriggered(key))
        {
            triggeredCutscenes.Add(key, true);
        }
    }

    public bool HasTriggered(string key)
    {
        return triggeredCutscenes.ContainsKey(key);
    }

    public void CompletedPuzzles(string key)
    {
        if (!PuzzleHasCompleted(key))
        {
            completedPuzzles.Add(key, true);
        }
    }

    public bool PuzzleHasCompleted(string key)
    {
        return completedPuzzles.ContainsKey(key);
    }
}

[System.Serializable]
public class ItemSaveData
{
    public string key;
    public int qtd;
}