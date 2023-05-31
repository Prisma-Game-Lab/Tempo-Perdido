using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Journal", menuName = "ScriptableObjects/Journal")]
public class JournalSO : ScriptableObject
{
    public SerializableDictionary<string, List<Letters>> totalLetters = new SerializableDictionary<string, List<Letters>>();
    private SerializableDictionary<string, List<Letters>> unlockedLettersByMailbox = new SerializableDictionary<string, List<Letters>>();
    public List<Letters> unlockedLetters = new List<Letters>();
    public bool canUnlockLetter = false;

    public void OnEnable()
    {
        unlockedLettersByMailbox.Clear();
        //unlockedLetters.Clear();
    }

    public void UnlockNewLetter(string mailboxId)
    {
        if (!unlockedLettersByMailbox.ContainsKey(mailboxId))
        {
            unlockedLettersByMailbox.Add(mailboxId, new List<Letters>());
        }

        if (canUnlockLetter && totalLetters[mailboxId].Count != unlockedLettersByMailbox[mailboxId].Count)
        {
            unlockedLetters.Add(totalLetters[mailboxId][unlockedLettersByMailbox[mailboxId].Count]);
            unlockedLettersByMailbox[mailboxId].Add(totalLetters[mailboxId][unlockedLettersByMailbox[mailboxId].Count]);
            canUnlockLetter = false;
        }
    }
}

[System.Serializable]
public class Letters
{
    [TextArea(3, 20)] public string letterText;
}
