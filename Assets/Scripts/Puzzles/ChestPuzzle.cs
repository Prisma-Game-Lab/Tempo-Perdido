using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPuzzle : ClickManager
{
    [SerializeField] private InventorySO inventory;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite openedSprite, closedSprite;
    [SerializeField] public GameObject handlePrefab;
    [SerializeField] private PuzzleSO puzzles;
    public bool isOpen;
    
    private void OnEnable()
    {
        puzzles.puzzleEvents["ChestPuzzle"].AddListener(SpawnHandle);
    }

    private void OnDisable()
    {
        puzzles.puzzleEvents["ChestPuzzle"].RemoveListener(SpawnHandle);
    }

    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        movementSO.initialPosition = Player.position;
        if (!interrupted)
        {
            InteractChest();
        }
        interrupted = false;
    }

    public void InteractChest()
    {
        CollectableObject hasHandle = inventory.inventoryItems.Find(x => x != null && x.key == "Handle");
        int handle = hasHandle != null ? hasHandle.qtd : 0;

        if (handle != 0)
        {
            isOpen = true;
        }

        if (isOpen)
        {
            //spriteRenderer.sprite = openedSprite;
            Debug.Log('A');
        }
        else
        {
            //spriteRenderer.sprite = closedSprite;
            Debug.Log('F');
        }
    }

    public void SpawnHandle()
    {
        handlePrefab.SetActive(true);
        Debug.Log("spawn");
    }

}
