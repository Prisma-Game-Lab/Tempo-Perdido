using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : ClickManager
{
    public string key;
    public string itemName;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        if (SceneObserver.HasItem(key))
        {
            Destroy(this.gameObject);
        }
    }
    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        movementSO.initialPosition = Player.position;
        if (!interrupted)
        {
            Collect();
        }
        interrupted = false;
    }

    public void Collect()
    {
        InventoryManager im = FindObjectOfType<InventoryManager>();
        im.AddItem(this);
        SceneObserver.CollectItem(key);
        Destroy(this.gameObject);
    }
}
