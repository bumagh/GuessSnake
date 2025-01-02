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
    public int Cute;
    public int Long;
    public int Toxicity;
    public int Intelligence;
    public int Wealth;
    public int Weight;
    public int Strength;
    public int Intimidation;
}

[System.Serializable]
public class SnakeConfigList
{
    public List<SnakeConfig> snakes;
}
