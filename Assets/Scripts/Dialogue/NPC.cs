using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : ClickManager
{
    public bool isClock;
    public bool isInteractive;
    public DialogueSO dialogue;

    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.EnqueueDialogue(dialogue.dialogue);
        dialogueManager.StartDialogue(dialogue, isClock, isInteractive);
    }
}
