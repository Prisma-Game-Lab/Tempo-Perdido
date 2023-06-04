using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : ClickManager
{
    public bool isClock;
    public bool isInteractive;
    public DialogueSO dialogue;

    public override void Interact()
    {
        base.Interact();
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.EnqueueDialogue(dialogue.dialogue);
        dialogueManager.StartDialogue(dialogue, isClock, isInteractive);
    }
}
