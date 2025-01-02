
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class SnakeConfigManager : MonoBehaviour
{
    public string configFilePath = "snakeConfig.json";  // 配置文件路径
    public static SnakeConfigManager instance;
    public bool isLoad = false;

    void Start()
    {
        instance = this;
    }



}
