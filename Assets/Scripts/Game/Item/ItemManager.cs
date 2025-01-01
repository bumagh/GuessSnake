using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public string configFilePath = "Assets/Resources/itemConfig.json";  // 配置文件路径
    public List<ItemConfig> itemConfigs;

    void Start()
    {
        LoadItemConfigs();
    }

    void LoadItemConfigs()
    {
        string json = File.ReadAllText(configFilePath);
        ItemConfigList configList = JsonUtility.FromJson<ItemConfigList>(json);
        itemConfigs = configList.items;

        foreach (var item in itemConfigs)
        {
            Debug.Log($"加载道具: {item.name} - {item.description}");
        }
    }

    public ItemConfig GetItemById(int itemId)
    {
        return itemConfigs.Find(item => item.itemId == itemId);
    }

    public List<ItemConfig> GetAvailableItems(int currentLevel)
    {
        return itemConfigs.FindAll(item => item.unlockLevel <= currentLevel);
    }
}