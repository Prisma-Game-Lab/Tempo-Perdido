using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalManager : MonoBehaviour
{
    [SerializeField] private JournalSO journal;

    [Header("UI elements")]
    [SerializeField] private GameObject journalCanvas;
    [SerializeField] private TMP_Text journalText;
    [SerializeField] private GameObject journalPopup;
    private int currentIndex = 0;

    private void OnEnable()
    {
        journal.recieveLetterEvent.AddListener(EnablePopup);
    }

    private void OnDisable()
    {
        journal.recieveLetterEvent.RemoveListener(EnablePopup);
    }

    public void OpenJournal()
    {
        if (journalPopup.activeSelf)
        {
            journalPopup.SetActive(false);
        }

        if (journalCanvas.gameObject.activeSelf)
        {
            journalCanvas.gameObject.SetActive(false);
        }
        else
        {
            journalCanvas.gameObject.SetActive(true);
            if (journal.unlockedLetters.Count > 0)
            {
                journalText.text = journal.unlockedLetters[currentIndex].letterText;
            }
            else
            {
                journalText.text = "";
            }
        }
    }

    public void ChangePage(int dir)
    {
        if (journal.unlockedLetters.Count > 0)
        {
            currentIndex += dir;

            if (currentIndex < 0)
            {
                currentIndex = journal.unlockedLetters.Count - 1;
            }
            else if (currentIndex >= journal.unlockedLetters.Count)
            {
                currentIndex = 0;
            }

            journalText.text = journal.unlockedLetters[currentIndex].letterText;
        }
    }

    private void EnablePopup()
    {
        journalPopup.SetActive(true);
    }
}
