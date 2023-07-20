using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : ClickManager
{
    [SerializeField] private DialogueSO monologue;
    [SerializeField] private InventorySO inventory;
    public int sceneIndex;
    public string requiredKey;
    public DialogueManager dialogueManager;


    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        movementSO.initialPosition = Player.position;
        if (!interrupted)
        {
            ChangeScene();
        }
        interrupted = false;
    }

    private void ChangeScene()
    {
        if (inventory.inventoryItems.Find(x => x.key == requiredKey) != null)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            dialogueManager.EnqueueDialogue(monologue.dialogue);
            dialogueManager.StartDialogue(monologue, false);
        }
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
