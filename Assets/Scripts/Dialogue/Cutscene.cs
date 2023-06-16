using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private DialogueSO monologue;
    private DialogueManager dialogueManager;
    private bool cutsceneTriggered;

    // Start is called before the first frame update
    void Start()
    {
        cutsceneTriggered = false;
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !cutsceneTriggered)
        {
            dialogueManager.EnqueueDialogue(monologue.dialogue);
            dialogueManager.StartDialogue(monologue, false);
            cutsceneTriggered = true;
        }
    }
}
