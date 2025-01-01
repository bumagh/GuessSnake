
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
    }

}
