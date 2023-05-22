using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    
    private Queue<DialogueStructure> sentences;
    
    void Start()
    {
        sentences = new Queue<DialogueStructure>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        dialogueBox.SetActive(true);

        sentences.Clear();

        foreach (DialogueStructure sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueStructure sentence = sentences.Dequeue();
        dialogueText.text = sentence.sentence;
        nameText.text = sentence.name;
    }

    void EndDialogue ()
    {
        dialogueBox.SetActive(false);
    }

}
