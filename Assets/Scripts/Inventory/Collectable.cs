using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : ClickManager
{
    public string itemName;
    public SpriteRenderer spriteRenderer;

    public override IEnumerator MoveToPoint(Vector2 point)
    {
        Debug.Log("Entrou");
        yield return base.MoveToPoint(point);
        Collect();
    }

    public void Collect()
    {
        InventoryManager im = FindObjectOfType<InventoryManager>();
        im.AddItem(this);
        Destroy(this.gameObject);
    }
}
