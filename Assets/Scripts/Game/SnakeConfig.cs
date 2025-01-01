using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SnakeConfig
{
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

public class SnakeConfigManager : MonoBehaviour
{
    public string configFilePath = "Assets/Resources/snakeConfig.json";  // 配置文件路径
    private List<SnakeConfig> snakeConfigs;

    void Start()
    {
        LoadSnakeConfig();
    }

    void LoadSnakeConfig()
    {
        string json = File.ReadAllText(configFilePath);
        SnakeConfigList snakeConfigList = JsonUtility.FromJson<SnakeConfigList>(json);
        snakeConfigs = snakeConfigList.snakes;

        // 生成蛇
        foreach (var snakeConfig in snakeConfigs)
        {
            GenerateSnake(snakeConfig);
        }
    }

    void GenerateSnake(SnakeConfig config)
    {
        GameObject snakeObject = new GameObject(config.name);
        Snake snakeScript = snakeObject.AddComponent<Snake>();
        snakeScript.snakeName = config.name;
        snakeScript.moveSpeed = config.speed;

        // 假设蛇的外观是一个Sprite，可以通过资源加载来设置
        Sprite snakeSprite = Resources.Load<Sprite>(config.appearance);
        snakeObject.AddComponent<SpriteRenderer>().sprite = snakeSprite;

        // 其他设置
        snakeScript.exchangeRate = config.exchangeRate;
    }
}
