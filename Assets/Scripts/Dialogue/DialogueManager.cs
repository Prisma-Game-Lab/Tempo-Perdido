using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TimeTravelSO timeTravelSO;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    public GameObject continueButton;
    public GameObject[] timeTravelButtons;

    private Queue<DialogueStructure> sentences;
    private bool isClock;

    void Start()
    {
        sentences = new Queue<DialogueStructure>();
        DisplayButtons(false);
    }

    public void StartDialogue(Dialogue dialogue, bool _isClock)
    {
        dialogueBox.SetActive(true);
        continueButton.SetActive(true);

        sentences.Clear();

        foreach (DialogueStructure sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        isClock = _isClock;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            if (!isClock)
            {
                EndDialogue();
            }
            else
            {
                continueButton.SetActive(false);
                dialogueText.text = "Viajar no tempo?";
                DisplayButtons(true);
            }
            return;
        }

        DialogueStructure sentence = sentences.Dequeue();
        dialogueText.text = sentence.sentence;
        nameText.text = sentence.name;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        DisplayButtons(false);
    }

    private void DisplayButtons(bool active)
    {
        foreach (GameObject button in timeTravelButtons)
        {
            button.SetActive(active);
        }
    }

    public void TimeTravel()
    {
        timeTravelSO.TimeTravel();
    }
}
