using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeCollect : MonoBehaviour
{
    [SerializeField] private JournalSO journal;
    void OnDisable()
    {
        Collectable collectable = GetComponent<Collectable>();
        if (collectable.key == "Handle")
        {
            journal.UnlockRecipe();
        }
        else if (collectable.key == "Garrafa")
        {
            journal.UnlockBottle();
        }
    }
}
