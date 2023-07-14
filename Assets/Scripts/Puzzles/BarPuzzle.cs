using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarPuzzle : MonoBehaviour
{
    public List<int> digits = new List<int>();
    public bool isCompleted = false;
    public List<Image> displays = new List<Image>();
    public List<Sprite> ingredients = new List<Sprite>();
    public GameObject RecipeObject;
    public string puzzleName;
    private int index = 0;

    void OnEnable()
    {
        SceneObserver.puzzleEvents["BarPuzzle"].AddListener(SpawnRecipe);
    }

    void OnDesable()
    {
        SceneObserver.puzzleEvents["BarPuzzle"].RemoveListener(SpawnRecipe);
    }


    void Start()
    {
        for (int i = 0; i < digits.Count; i++)
        {
            digits[i] = 0;
        }
    }

    public void ChangeDigits(int change)
    {
        digits[index] += change;

        if (digits[index] > 3)
        {
            digits[index] = 0;
        }
        else if (digits[index] < 0)
        {
            digits[index] = 3;
        }

        displays[index].sprite = ingredients[digits[index]];
        CheckDigits();
    }

    public void CheckDigits()
    {
        for (int i = 0; i < digits.Count; i++)
        {
            if (digits[i] != SceneObserver.playerData.digits[i])
            {
                return;
            }
        }

        Debug.Log("puzzle concluido!");
        isCompleted = true;
        SceneObserver.InvokeEvent(puzzleName);
        SelfDestruct();
    }

    public void SpawnRecipe()
    {
        RecipeObject.SetActive(true);
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }

    public void SetIndex(int _index)
    {
        index = _index;
    }
}
