using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/Dialogue")]
public class DialogueSO : ScriptableObject
{
    public Dialogue dialogue;
    public List<DialogueSO> answersDialogues;
    public List<string> answers;

}
