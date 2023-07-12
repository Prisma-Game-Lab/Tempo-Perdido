using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventorySO inventory;
    public List<GameObject> inventoryItems = new List<GameObject>();
    public GameObject selector;
    private int selectedItem = 0;
    public ItemVisuals visuals;

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            if (visuals.visuals.ContainsKey(inventory.inventoryItems[i].key))
            {
              inventory.inventoryItems[i].sprite = visuals.SetVisuals(inventory.inventoryItems[i].key);  
            }
        }

        UpdateView();
    }

    public void ChangeSelectedItem(int index)
    {
        selectedItem = index;
        selector.transform.position = inventoryItems[index].transform.position;
    }

    public void AddItem(Collectable collectable)
    {
        CollectableObject obj = new CollectableObject(collectable.itemName, collectable.spriteRenderer.sprite);
        inventory.AddItem(obj);
        UpdateView();
        SceneObserver.playerData.KeepInventory(inventory.inventoryItems);
    }

    public void UseItem()
    {
        inventory.RemoveItem(selectedItem);
        UpdateView();
        SceneObserver.playerData.KeepInventory(inventory.inventoryItems);
    }

    public void UpdateView()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            Image renderer = inventoryItems[i].GetComponent<Image>();

            if (inventory.inventoryItems[i].sprite == null)
            {
                renderer.enabled = false;
            }
            else
            {
                renderer.enabled = true;
                renderer.sprite = inventory.inventoryItems[i].sprite;
            }
        }
    }
}
