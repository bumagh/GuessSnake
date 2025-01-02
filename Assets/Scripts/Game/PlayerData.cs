using Unity.VisualScripting;
using UnityEngine;

public static class PlayerData
{
    public const string LoginTime = "LoginTime";
    public const string Items = "Items";
    public const string Soliders = "Soliders";
    public const string BattleSoldier = "BattleSoldier";
    public const string BgmVolume = "BgmVolume";
    public const string Coin = "Coin";
    public const string LevelId = "LevelId";
    public static string userId;

    public static void SetUserId(string user)
    {
        userId = user;
    }

    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(GetKey(key), value);
    }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(GetKey(key), value);
    }

    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(GetKey(key), value);
    }

    public static int GetInt(string key, int defaultValue = default)
    {
        return PlayerPrefs.GetInt(GetKey(key), defaultValue);
    }

    public static string GetString(string key, string defaultValue = default)
    {
        return PlayerPrefs.GetString(GetKey(key), defaultValue);
    }

    public static float GetFloat(string key, float defaultValue = default)
    {
        return PlayerPrefs.GetFloat(GetKey(key), defaultValue);
    }

    private static string GetKey(string key)
    {
        return $"{userId}-{key}";
    }
    public static void UpdateData(string key, int value)
    {
        // switch (key)
        // {
        //     case "HP":
        //         PlayerData.SetInt(PlayerData.Hp, PlayerData.GetInt(PlayerData.Hp, 1) + value);
        //         break;
        //     case "MP":
        //         PlayerData.SetInt(PlayerData.Mp, PlayerData.GetInt(PlayerData.Mp, 1) + value);

        //         break;
        //     case "ATK":
        //         PlayerData.SetInt(PlayerData.Atk, PlayerData.GetInt(PlayerData.Atk, 1) + value);

        //         break;
        //     case "SP":
        //         PlayerData.SetInt(PlayerData.Sp, PlayerData.GetInt(PlayerData.Sp, 1) + value);

        //         break;
        //     case "DEF":
        //         PlayerData.SetInt(PlayerData.Def, PlayerData.GetInt(PlayerData.Def, 1) + value);

        //         break;
        //     default:
        //         break;
        // }
    }
}
