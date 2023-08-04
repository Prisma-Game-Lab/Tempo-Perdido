using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : ClickManager
{
    public bool isClock;
    public bool isRooster;
    public bool isTea;
    public DialogueSO dialogue;
    public DialogueSO endDialogue;

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
        if (SceneObserver.playerData.HasItem("Garrafa") && !SceneObserver.playerData.hasTriggeredEnd && isClock)
        {
            dialogueManager.EnqueueDialogue(endDialogue.dialogue);
            dialogueManager.StartDialogue(endDialogue, !isClock);
            SceneObserver.playerData.hasTriggeredEnd = true;
        }
        else if (isRooster && SceneObserver.playerData.hasTriggeredEnd)
        {
            AudioManager.instance.PlaySfx("WeatherVane");
            dialogueManager.EnqueueDialogue(endDialogue.dialogue);
            dialogueManager.StartDialogue(endDialogue, isClock, isRooster);
        }
        else if (isTea)
        {
            dialogueManager.EnqueueDialogue(dialogue.dialogue);
            dialogueManager.StartDialogue(dialogue, isClock, isRooster, isTea);
        }
        else
        {
            dialogueManager.EnqueueDialogue(dialogue.dialogue);
            dialogueManager.StartDialogue(dialogue, isClock);
        }
    }
}
