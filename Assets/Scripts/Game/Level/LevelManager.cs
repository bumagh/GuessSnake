using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public SnakeManager snakeManager;  // 控制蛇的管理器
    public static LevelManager instance;
    public float difficultyIncreaseInterval = 10f;  // 每10秒增加难度
    private float difficultyTimer;
    private int currentLevel = 1;
    public string configFilePath = "Assets/Resources/Config/levelConfig.json";
    public List<LevelConfig> levelConfigs;
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        // difficultyTimer += Time.deltaTime;
        // if (difficultyTimer >= difficultyIncreaseInterval)
        // {
        //     IncreaseDifficulty();
        //     difficultyTimer = 0;
        // }
    }

    void IncreaseDifficulty()
    {
        currentLevel++;

        // 增加蛇的速度和交换频率
        foreach (var snake in snakeManager.snakes)
        {
            snake.moveSpeed += 0.5f;  // 增加蛇的速度
            snake.exchangeRate -= 0.1f;  // 加快蛇交换的频率
        }

        // 增加新的蛇种类，假设到当前关卡解锁更多的蛇种类
        if (currentLevel % 3 == 0)
        {
            // 解锁新蛇
            // snakeManager.AddNewSnake();
        }
    }

    IEnumerator DelayedAction()
    {
        // 等待 1 秒
        yield return new WaitForSeconds(1f);
        EventManager.DispatchEvent<bool>(EventName.GameUIShowLevelQuesPanel, true);
    }
    void Start()
    {
        LoadLevelConfigs();
        LoadLevel(PlayerData.GetInt(PlayerData.LevelId, 1));  // 加载第1关
    }

    void LoadLevelConfigs()
    {
        string json = File.ReadAllText(configFilePath);
        LevelConfigList configList = JsonUtility.FromJson<LevelConfigList>(json);
        levelConfigs = configList.levels;
    }

    public void LoadLevel(int level)
    {
        LevelConfig currentLevel = levelConfigs.Find(l => l.level == level);

        if (currentLevel != null)
        {
            // Debug.Log($"加载关卡: {currentLevel.level} - {currentLevel.theme}");
            EventManager.DispatchEvent<string, string>(EventName.GameUISetLevelInfo, currentLevel.level.ToString(), currentLevel.theme);
            // 设置背景
            // SetBackground(currentLevel.background);
            // 生成蛇
            GenerateSnakes(currentLevel);
            // 设置道具
            // SetupSpecialItem(currentLevel.specialItem, currentLevel.specialItemChance);
        }
        else
        {
            Debug.LogError("未找到关卡配置！");
            Tools.ShowTip("您已通关");
        }
        GameManager.instance.isGaming = true;
        StartCoroutine(DelayedAction());
    }

    void SetBackground(string backgroundName)
    {
        // 假设背景是一个图片或材质，动态加载
        Debug.Log($"设置背景: {backgroundName}");
        // 示例代码：GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(backgroundName);
    }

    void GenerateSnakes(LevelConfig levelConfig)
    {
        SnakeManager.instance.AddNewSnake(levelConfig);
        // Debug.Log($"生成蛇 {i + 1}，速度: {speed}，交换频率: {exchangeRate}");
        // 示例代码：Instantiate(snakePrefab, position, Quaternion.identity).GetComponent<Snake>().Setup(speed, exchangeRate);
    }

    void SetupSpecialItem(string itemName, int chance)
    {
        Debug.Log($"设置道具: {itemName}，出现概率: {chance}%");
        // 示例代码：根据概率生成对应道具
    }
}
