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
                GetComponent<RectTransform>().localScale = new Vector3(0.2f, 0.2f, 1.0f);
                break;
            case "CogL":
                currentCog = Cogs.LARGE;
                image.sprite = cogSprites[0];
                GetComponent<RectTransform>().localScale = new Vector3(2f, 2f, 1.0f);
                break;
            case "CogM":
                currentCog = Cogs.MEDIUM;
                image.sprite = cogSprites[1];
                GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case "CogS":
                currentCog = Cogs.SMALL;
                image.sprite = cogSprites[2];
                GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 1.0f);
                break;
            default:
                break;
        }
        
        if (currentCog == rightCog)
        {
            if (image.gameObject.GetComponent<ObjectRotation>() == null)
            {
                image.gameObject.AddComponent<ObjectRotation>();
            }
        }
        else
        {
            if (image.gameObject.GetComponent<ObjectRotation>() != null)
            {
                GetComponent<ObjectRotation>().StopRotation();
            }
        }
    }

    public bool CheckPlacement(string cogType)
    {
        float radius = cogType == "CogL" ? cogRadius[0] : cogType == "CogM" ? cogRadius[1] : cogRadius[2];
        Collider2D[] foundCogs = Physics2D.OverlapCircleAll(transform.position, radius, cogLayer);
        int cols = 0;

        foreach (Collider2D col in foundCogs)
        {
            if (col.gameObject != this.gameObject)
            {
                cols++;
            }
        }

        if (cols > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
