using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InventorySO", menuName = "ScriptableObjects/Inventory")]
public class InventorySO : ScriptableObject
{
    public int inventoryCapacity;
    public List<CollectableObject> inventoryItems = new List<CollectableObject>();

    private void OnEnable()
    {
        for (int i = 0; i < inventoryCapacity; i++)
        {
            inventoryItems[i].key = "";
            inventoryItems[i].qtd = 0;
            inventoryItems[i].sprite = null;
        }

        int index = 0;

        foreach (ItemSaveData item in SceneObserver.playerData.inventory)
        {
            inventoryItems[index].key = item.key;
            inventoryItems[index].qtd = item.qtd;
            index++;
        }
    }

    public void AddItem(CollectableObject obj)
    {
        CollectableObject current = inventoryItems.Find(x => x != null && x.key == obj.key);

        if (current != null)
        {
            inventoryItems[inventoryItems.IndexOf(current)].qtd++;
            return;
        }

        for (int i = 0; i < inventoryCapacity; i++)
        {
            if (inventoryItems[i].key == "")
            {
                inventoryItems[i] = obj;
                break;
            }
        }
    }

    public void RemoveItem(int index)
    {
        if (inventoryItems[index].qtd > 1)
        {
            inventoryItems[index].qtd--;
        }
        else
        {
            inventoryItems[index].key = "";
            inventoryItems[index].qtd = 0;
            inventoryItems[index].sprite = null;
        }
    }
}

[System.Serializable]
public class CollectableObject
{
    public string key;
    public int qtd;
    public Sprite sprite;

    public CollectableObject(string _key, Sprite _sprite)
    {
        key = _key;
        qtd = 1;
        sprite = _sprite;
    }
}
