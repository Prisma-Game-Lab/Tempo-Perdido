using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Journal", menuName = "ScriptableObjects/Journal")]
public class JournalSO : ScriptableObject
{
    public SerializableDictionary<string, List<Letters>> totalLetters = new SerializableDictionary<string, List<Letters>>();
    private SerializableDictionary<string, List<Letters>> unlockedLettersByMailbox = new SerializableDictionary<string, List<Letters>>();
    public List<Letters> unlockedLetters = new List<Letters>();
    public bool canUnlockLetter = false;
    public UnityEvent recieveLetterEvent;

    public void OnEnable()
    {
        if (recieveLetterEvent == null)
        {
            recieveLetterEvent = new UnityEvent();
        }

        unlockedLettersByMailbox.Clear();
        unlockedLetters.Clear();
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
            recieveLetterEvent?.Invoke();
        }
    }

    public void UnlockRecipe()
    {
        List<int> password = SceneObserver.playerData.digits;
        string content = "Lista de compras: \n\n";


        for (int i = 0; i < password.Count; i++)
        {
            content = content + (i + 1).ToString() + ". ";
            switch (password[i])
            {
                case 0:
                    content = content + "Água \n";
                    break;
                case 1:
                    content = content + "Hortelã \n";
                    break;
                case 2:
                    content = content + "Limão \n";
                    break;
                case 3:
                    content = content + "Açúcar \n";
                    break;
                default:
                    break;
            }
        }

        Letters recipe = new Letters();
        recipe.letterText = content;
        unlockedLetters.Add(recipe);
    }
}

[System.Serializable]
public class Letters
{
    [TextArea(3, 20)] public string letterText;
}
