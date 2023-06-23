using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public string key;
    [SerializeField] private DialogueSO monologue;
    private DialogueManager dialogueManager;
    private bool cutsceneTriggered;

    void Start()
    {
        cutsceneTriggered = SceneObserver.HasTriggered(key);
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !cutsceneTriggered)
        {
            dialogueManager.EnqueueDialogue(monologue.dialogue);
            dialogueManager.StartDialogue(monologue, false);
            SceneObserver.TriggerCutscene(key);
            cutsceneTriggered = true;
        }
    }
}
