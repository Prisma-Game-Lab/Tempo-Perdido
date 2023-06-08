using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventorySO inventory;
    List<Sprite> inventoryItems = new List<Sprite>();
    int selectedItem = 0;

    public void ChangeSelectedItem(int index)
    {
        selectedItem = index;
    }

    public void AddItem(Collectable collectable)
    {
        CollectableObject obj = new CollectableObject(collectable.itemName, collectable.spriteRenderer.sprite);
        inventory.AddItem(obj);
        UpdateView();
    }

    public void UseItem()
    {
        inventory.RemoveItem(selectedItem);
        UpdateView();
    }

    public void UpdateView()
    {

    }
}
