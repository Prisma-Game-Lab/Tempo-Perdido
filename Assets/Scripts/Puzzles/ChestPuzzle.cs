using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPuzzle : ClickManager
{
    public string key;

    [SerializeField] private InventorySO inventory;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite openedSprite, closedSprite;
    [SerializeField] public GameObject handlePrefab;

    public bool isOpen;
    private bool isFixed;

    private void OnEnable()
    {
        SceneObserver.puzzleEvents["ChestPuzzle"].AddListener(FixVault);
        isOpen = SceneObserver.playerData.PuzzleHasCompleted(key);
        isFixed = SceneObserver.playerData.PuzzleHasCompleted(key);
    }

    private void OnDisable()
    {
        SceneObserver.puzzleEvents["ChestPuzzle"].RemoveListener(FixVault);
    }

    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        movementSO.initialPosition = Player.position;
        if (!interrupted && isFixed)
        {
            InteractChest();
        }
        interrupted = false;
    }

    public void InteractChest()
    {
        if (isFixed && !isOpen)
        {
            isOpen = true;
            SceneObserver.playerData.CompletedPuzzles(key);
            SpawnHandle();
            SceneObserver.SaveGame();
        }

        if (isOpen)
        {
            spriteRenderer.sprite = openedSprite;
        }
        else
        {
            spriteRenderer.sprite = closedSprite;
        }
    }

    public void SpawnHandle()
    {
        handlePrefab.SetActive(true);
    }

    public void FixVault()
    {
        isFixed = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnHoverEnter();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnHoverExit();
        }
    }
}
