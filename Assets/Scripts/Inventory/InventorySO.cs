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
        inventoryItems.Clear();
        for (int i = 0; i < inventoryCapacity; i++)
        {
            inventoryItems.Add(null);
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
            if (inventoryItems[i].key == null)
            {
                obj.slot = i;
                inventoryItems[i] = obj;
                break;
            }
        }
    }

    public void RemoveItem(int index)
    {
        inventoryItems[index] = null;
    }
}

[System.Serializable]
public class CollectableObject
{
    public string key;
    public int qtd;
    public int slot;
    public Sprite sprite;

    public CollectableObject(string _key, Sprite _sprite)
    {
        key = _key;
        qtd = 1;
        slot = 0;
        sprite = _sprite;
    }
}
