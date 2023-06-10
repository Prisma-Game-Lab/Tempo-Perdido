using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Cogs
{
    NONE,
    LARGE,
    MEDIUM,
    SMALL
}

public class Pin : MonoBehaviour
{
    [Header("General Info")]
    [SerializeField] private Sprite[] cogSprites;
    [SerializeField] private float[] cogRadius;
    [SerializeField] private Sprite pinSprite;
    [SerializeField] private LayerMask cogLayer;

    [Header("Pin data")]
    public Cogs rightCog;

    public Cogs currentCog;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        currentCog = Cogs.NONE;
    }

    public void PlaceCog(string cogType)
    {
        switch (cogType)
        {
            case "None":
                currentCog = Cogs.NONE;
                image.sprite = pinSprite;
                break;
            case "CogL":
                currentCog = Cogs.LARGE;
                image.sprite = cogSprites[0];
                break;
            case "CogM":
                currentCog = Cogs.MEDIUM;
                image.sprite = cogSprites[1];
                break;
            case "CogS":
                currentCog = Cogs.SMALL;
                image.sprite = cogSprites[2];
                break;
            default:
                break;
        }
    }

    public bool CheckPlacement(string cogType)
    {
        float radius = cogType == "CogL" ? cogRadius[0] : cogType == "CogM" ? cogRadius[1] : cogRadius[2];
        Collider2D[] foundCogs = Physics2D.OverlapCircleAll(transform.position, radius, cogLayer);

        if (foundCogs.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
