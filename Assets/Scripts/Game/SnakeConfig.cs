using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SnakeConfig
{
    public int id;
    public string name;
    public string appearance;
    public float speed;
    public float exchangeRate;
}

[System.Serializable]
public class SnakeConfigList
{
    public List<SnakeConfig> snakes;
}
