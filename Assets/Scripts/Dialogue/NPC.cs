using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : ClickManager
{
    public bool isClock;
    public Dialogue dialogue;

    public override void Interact()
    {
        base.Interact();
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, isClock);
    }
}
