using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : ClickManager
{
    public bool isClock;
    public DialogueSO dialogue;

    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        movementSO.initialPosition = Player.position;
        if (!interrupted)
        {
            TriggerDialogue();
        }
        interrupted = false;
    }

    public void TriggerDialogue()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.EnqueueDialogue(dialogue.dialogue);
        dialogueManager.StartDialogue(dialogue, isClock);
    }
}
