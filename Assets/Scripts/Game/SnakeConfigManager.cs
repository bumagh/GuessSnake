
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SnakeConfigManager : MonoBehaviour
{
    public string configFilePath = "Assets/Resources/Config/snakeConfig.json";  // 配置文件路径
    public static SnakeConfigManager instance;
    public List<SnakeConfig> snakeConfigs;
    public bool isLoad = false;

    void Start()
    {
        instance = this;
        LoadSnakeConfig();
    }

    public void LoadSnakeConfig()
    {
        string json = File.ReadAllText(configFilePath);
        SnakeConfigList snakeConfigList = JsonUtility.FromJson<SnakeConfigList>(json);
        snakeConfigs = snakeConfigList.snakes;
        isLoad = true;
        // 生成蛇
        // foreach (var snakeConfig in snakeConfigs)
        // {
        //     GenerateSnake(snakeConfig);
        // }
    }

    void GenerateSnake(SnakeConfig config)
    {
        GameObject snakeObject = new GameObject(config.name);
        Snake snakeScript = snakeObject.AddComponent<Snake>();
        snakeScript.snakeName = config.name;
        snakeScript.moveSpeed = config.speed;

        // 假设蛇的外观是一个Sprite，可以通过资源加载来设置
        Sprite snakeSprite = Resources.Load<Sprite>("Sprites/" + config.appearance);
        snakeObject.AddComponent<SpriteRenderer>().sprite = snakeSprite;

        // 其他设置
        snakeScript.exchangeRate = config.exchangeRate;
    }
}
