using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoSingleton<GameData>
{

    // private readonly Dictionary<string, SoldierBase> soldierDict = new Dictionary<string, SoldierBase>();
    private readonly string[] battleSoldiers = new string[4];
    private readonly Dictionary<int, string> soldierUpDict = new Dictionary<int, string>();
    public Dictionary<int, int> items = new Dictionary<int, int>();
    // public Dictionary<int, Goods> equips = new Dictionary<int, Goods>();
    // public Dictionary<string, SoldierBase> SoldierDict => soldierDict;

    protected override void Initialize()
    {
#if UNITY_EDITOR
        //PlayerPrefs.DeleteAll();
        // PlayerData.SetUserId(UnityEngine.Random.Range(0, 100).ToString());
#endif
    }

    async void Start()
    {
        await ConfigData.LoadConfigsAsync();
    }
    public void InitPlayerData()
    {
        if (PlayerData.GetInt(PlayerData.LevelId, 1) == 1)
        {
            PlayerData.SetInt(PlayerData.LevelId, 1);
            string uuid = Guid.NewGuid().ToString();
            PlayerData.SetUserId(uuid);
        }
    }
    public string[] GetBattleSoldiers()
    {
        return battleSoldiers;
    }

    public void UpdateBattleSodiers(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            battleSoldiers[i] = array[i];
        }
        PlayerData.SetString(
            PlayerData.BattleSoldier,
            string.Join('#', battleSoldiers.Where(s => !string.IsNullOrEmpty(s)))
        );
    }

    public void RemoveBattleSodier(string uuid)
    {
        for (int i = 0; i < battleSoldiers.Length; i++)
        {
            if (battleSoldiers[i] == uuid)
            {
                battleSoldiers[i] = null;
                PlayerData.SetString(
                    PlayerData.BattleSoldier,
                    string.Join('#', battleSoldiers.Where(s => !string.IsNullOrEmpty(s)))
                );
                return;
            }
        }
        Debug.Log("SoldierId not found in the array.");
    }


    private void UpdateLoginTime()
    {
        PlayerData.SetString(PlayerData.LoginTime, DateTime.Now.ToString("yyyy-MM-dd"));
    }

    private DateTime GetLoginTime()
    {
        DateTime.TryParse(
            PlayerData.GetString(
                PlayerData.LoginTime,
                DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
            ),
            out var result
        );
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="exp"></param>
    /// <returns>还差多少升级</returns>
    private void UpdateItems()
    {
        List<string> list = new List<string>();
        foreach (var item in items)
        {
            if (item.Value <= 0)
                continue;
            list.Add($"{item.Key}#{item.Value}");
        }
        PlayerData.SetString(PlayerData.Items, string.Join('|', list));
    }



    private void LoadBattleSoldier()
    {
        var str = PlayerData.GetString(PlayerData.BattleSoldier, "1000");
        var array = str.Split('#');
        for (var i = 0; i < array.Length; i++)
        {
            battleSoldiers[i] = array[i];
        }
    }

    public void AddItemToKnapsack(int itemId, int count)
    {
        if (items.ContainsKey(itemId))
        {
            items[itemId] += count;
        }
        else
        {
            items[itemId] = count;
        }
        UpdateItems();
    }

    public void UseItemByCount(int itemId, int count)
    {
        if (items.ContainsKey(itemId))
        {
            items[itemId] = items[itemId] - count;
            if (items[itemId] <= 0)
            {
                items.Remove(itemId);
            }
        }
        UpdateItems();
    }



    public int GetCoinItemCount()
    {
        int coinCount;
        items.TryGetValue(1001, out coinCount);
        return coinCount;
    }

    public int GetItemCount(string itemId)
    {
        int count;
        items.TryGetValue(int.Parse(itemId), out count);
        return count;
    }

    private void OnDestroy()
    {

    }

}
