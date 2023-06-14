using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CogsManager : MonoBehaviour
{
    [Header("Puzzle Elemets")]
    [SerializeField] private InventorySO inventory;
    [SerializeField] private List<Pin> pins = new List<Pin>();
    [SerializeField] private bool puzzleCompleted;

    [Header("UI Elements")]
    [SerializeField] private Button restartButton;
    [SerializeField] private Button backButton;
    [SerializeField] private List<Image> cogImages = new List<Image>();
    [SerializeField] private List<Sprite> cogSprites = new List<Sprite>();
    [SerializeField] private GameObject cogSelector;
    private Dictionary<int, string> cogsDict = new Dictionary<int, string>();

    private int selectedPin;

    // Start is called before the first frame update
    void Start()
    {
        puzzleCompleted = false;

        for (int i = 0; i < cogImages.Count; i++)
        {
            cogsDict.Add(i, "");
        }

        cogSelector.SetActive(false);
    }

    private void UpdateCanvas()
    {
        cogSelector.SetActive(true);

        for (int i = 0; i < cogImages.Count; i++)
        {
            cogImages[i].gameObject.SetActive(false);
        }

        CollectableObject hasL = inventory.inventoryItems.Find(x => x != null && x.key == "CogL");
        CollectableObject hasM = inventory.inventoryItems.Find(x => x != null && x.key == "CogM");
        CollectableObject hasS = inventory.inventoryItems.Find(x => x != null && x.key == "CogS");

        int cogLs = hasL != null ? hasL.qtd : 0;
        int cogMs = hasM != null ? hasM.qtd : 0;
        int cogSs = hasS != null ? hasS.qtd : 0;

        for (int i = 0; i < cogLs; i++)
        {
            cogImages[i].gameObject.SetActive(true);
            cogImages[i].sprite = cogSprites[0];
            cogsDict[i] = "CogL";
        }

        for (int i = cogLs; i < cogMs + cogLs; i++)
        {
            cogImages[i].gameObject.SetActive(true);
            cogImages[i].sprite = cogSprites[1];
            cogsDict[i] = "CogM";
        }

        for (int i = cogMs + cogLs; i < cogSs + cogMs + cogLs; i++)
        {
            cogImages[i].gameObject.SetActive(true);
            cogImages[i].sprite = cogSprites[2];
            cogsDict[i] = "CogS";
        }
    }

    public void SelectPin(int index)
    {
        selectedPin = index;
        UpdateCanvas();
    }

    public void InsertCog(int key)
    {
        if (!pins[selectedPin].CheckPlacement(cogsDict[key]))
        {
            //TODO: Sound feedback
            cogSelector.SetActive(false);
            Debug.Log("The cog does not fit here");
            return;
        }

        if (pins[selectedPin].currentCog != Cogs.NONE)
        {
            if (pins[selectedPin].currentCog == Cogs.LARGE)
            {
                inventory.AddItem(new CollectableObject("CogL", cogSprites[0]));
            }
            else if (pins[selectedPin].currentCog == Cogs.MEDIUM)
            {
                inventory.AddItem(new CollectableObject("CogM", cogSprites[1]));
            }
            else if (pins[selectedPin].currentCog == Cogs.SMALL)
            {
                inventory.AddItem(new CollectableObject("CogS", cogSprites[2]));
            }
        }

        pins[selectedPin].PlaceCog(cogsDict[key]);
        cogSelector.SetActive(false);
        CheckCompletion();

        int itemIndex = inventory.inventoryItems.IndexOf(inventory.inventoryItems.Find(x => x.key == cogsDict[key]));

        inventory.RemoveItem(itemIndex);
    }

    public void CheckCompletion()
    {
        foreach (Pin pin in pins)
        {
            if (pin.currentCog != pin.rightCog)
            {
                return;
            }
        }

        puzzleCompleted = true;
        Debug.Log("Puzzle completed");
    }

    public void RestartPuzzle()
    {
        foreach (Pin pin in pins)
        {
            if (pin.currentCog == Cogs.LARGE)
            {
                inventory.AddItem(new CollectableObject("CogL", cogSprites[0]));
            }
            else if (pin.currentCog == Cogs.MEDIUM)
            {
                inventory.AddItem(new CollectableObject("CogM", cogSprites[1]));
            }
            else if (pin.currentCog == Cogs.SMALL)
            {
                inventory.AddItem(new CollectableObject("CogS", cogSprites[2]));
            }

            pin.PlaceCog("None");
        }
    }

    public void SelfDestruct()
    {
        if (!puzzleCompleted)
        {
            RestartPuzzle();
        }

        Destroy(gameObject);
    }

}
