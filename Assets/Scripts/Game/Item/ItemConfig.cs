using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ItemConfig
{
    public int itemId;
    public string name;
    public string description;
    public string type;
    public string icon;
    public float duration;
    public float effectStrength;
    public int spawnRate;
    public int unlockLevel;
    public string additionalNote;
}

[System.Serializable]
public class ItemConfigList
{
    public List<ItemConfig> items;
}