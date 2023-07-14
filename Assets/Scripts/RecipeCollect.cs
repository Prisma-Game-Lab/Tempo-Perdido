using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCollect : MonoBehaviour
{
    [SerializeField] private JournalSO journal;
    void OnDisable()
    {
        journal.UnlockRecipe();
    }
}
