using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarPuzzle : PuzzleObject
{
    public List<int> digits = new List<int>();
    public bool isCompleted = false;
    public string puzzleName;
    public List<TMP_Text> displays = new List<TMP_Text>();
    
    void Start()
    {
        for (int i = 0; i < digits.Count; i++)
        {
            digits.Add(0);
        }
    }

    public void ChangeDigits(int index, int change)
    {
        digits[index]+=change;
        displays[index].text = digits[index].ToString();
    }

    public void CheckDigits()
    {
        for (int i = 0; i < digits.Count; i++)
        {
            if (digits[i]!= SceneObserver.playerData.digits[i])
            {
                return;
            }
        }

        Debug.Log("puzzle concluido!");
        isCompleted = true;
        SceneObserver.InvokeEvent(puzzleName);
    }
}
