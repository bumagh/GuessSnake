using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class LevelConfig
{
    public int level;
    public string theme;
    public string levelQues;
    public int levelAns;
    public string reward;
    public string background;
    public int snakeCount;
    public int showType;//0static1move
    public string snakeIds;//0static1move
    public float snakeSpeed;
    public float exchangeRate;
    public string specialItem;
    public int specialItemChance;
    public string additionalNote;
}

[System.Serializable]
public class LevelConfigList
{
    public List<LevelConfig> levels;
}

