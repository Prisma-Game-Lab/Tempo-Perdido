using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemVisuals
{
    public SerializableDictionary<string, Sprite> visuals = new SerializableDictionary<string, Sprite>();

    public Sprite SetVisuals(string key)
    {
        return visuals[key];
    }

}
