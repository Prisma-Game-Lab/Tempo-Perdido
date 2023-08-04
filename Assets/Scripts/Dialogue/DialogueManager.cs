using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private MovementSO movementSO;
    [SerializeField] private InventorySO inventorySO;

    [SerializeField] private TimeTravelSO timeTravelSO;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    public GameObject continueButton;
    public GameObject[] timeTravelButtons;
    public GameObject[] endButtons;
    public GameObject[] answerButtons;

    private Queue<DialogueStructure> sentences;
    private DialogueSO currentDialogue;
    private bool isClock;
    private bool isRooster;
    private bool isTea;

    void Start()
    {
        sentences = new Queue<DialogueStructure>();
        DisplayButtons(false);
        DisplayEndButtons(false);
    }

    public void StartDialogue(DialogueSO obj, bool _isClock, bool _isRooster = false, bool _isTea = false)
    {
        AudioManager.instance.PlaySfx("SpeechBubble");
        movementSO.canMove = false;
        dialogueBox.SetActive(true);
        continueButton.SetActive(true);

        isClock = _isClock;
        isRooster = _isRooster;
        isTea = _isTea;
        currentDialogue = obj;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            if (!isClock && !isRooster && !isTea && currentDialogue.answers.Count == 0)
            {
                AudioManager.instance.PlaySfx("SpeechNext");
                EndDialogue();
            }
            else if (isClock && currentDialogue.answers.Count == 0)
            {
                AudioManager.instance.PlaySfx("SpeechNext");
                continueButton.SetActive(false);
                dialogueText.text = "Viajar no tempo?";
                DisplayButtons(true);
            }
            else if (isRooster && currentDialogue.answers.Count == 0)
            {
                AudioManager.instance.PlaySfx("SpeechNext");
                continueButton.SetActive(false);
                dialogueText.text = "Beber da garrafa?";
                DisplayEndButtons(true);
            }
            else if (isTea && currentDialogue.answers.Count == 0)
            {
                AudioManager.instance.PlaySfx("SpeechNext");
                continueButton.SetActive(false);
                dialogueText.text = "Beber o chá?";
                DisplayEndButtons(true);
            }
            else if (currentDialogue.answers.Count > 0)
            {
                continueButton.SetActive(false);

                for (int i = 0; i < currentDialogue.answers.Count; i++)
                {
                    answerButtons[i].SetActive(true);
                    answerButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = currentDialogue.answers[i];
                }
            }
            return;
        }

        AudioManager.instance.PlaySfx("SpeechNext");
        DialogueStructure sentence = sentences.Dequeue();
        dialogueText.text = sentence.sentence;
        nameText.text = sentence.name;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        DisplayButtons(false);
        movementSO.canMove = true;
    }

    private void DisplayButtons(bool active)
    {
        foreach (GameObject button in timeTravelButtons)
        {
            button.SetActive(active);
        }
    }

    private void DisplayEndButtons(bool active)
    {
        foreach (GameObject button in endButtons)
        {
            button.SetActive(active);
        }
    }

    public void TimeTravel()
    {
        movementSO.canMove = true;
        timeTravelSO.TimeTravel();
    }

    public void GoodEnd()
    {
        movementSO.canMove = true;
        inventorySO.ClearInventory();
        SceneObserver.playerData = new PlayerData();
        SceneObserver.playerData.ResetLoop();
        SceneManager.LoadScene("GoodEnding");
    }

    public void BadEnd()
    {
        movementSO.canMove = true;
        inventorySO.ClearInventory();
        SceneObserver.playerData = new PlayerData();
        SceneObserver.playerData.ResetLoop();
        SceneManager.LoadScene("Game_Future");
    }

    public void EnqueueDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach (DialogueStructure sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }

    public void AnswerDialogue(int index)
    {
        for (int i = 0; i < currentDialogue.answers.Count; i++)
        {
            answerButtons[i].SetActive(false);
        }
        AudioManager.instance.PlaySfx("SpeechAnswer");
        EnqueueDialogue(currentDialogue.answersDialogues[index].dialogue);
        StartDialogue(currentDialogue.answersDialogues[index], isClock);
    }
}
