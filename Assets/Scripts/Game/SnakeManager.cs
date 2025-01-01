using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    public List<Snake> snakes;  // 存储所有蛇的列表
    public float exchangeInterval = 2f;  // 交换蛇的时间间隔
    private float exchangeTimer;
    public static SnakeManager instance;
    void Start()
    {
        instance = this;
        exchangeTimer = exchangeInterval;
    }

    void Update()
    {
        // 定时交换蛇
        exchangeTimer -= Time.deltaTime;
        if (exchangeTimer <= 0)
        {
            ExchangeSnakePositions();
            exchangeTimer = exchangeInterval;  // 重置交换时间
        }
    }

    // 交换两只蛇的位置
    void ExchangeSnakePositions()
    {
        int index1 = Random.Range(0, snakes.Count);
        int index2 = Random.Range(0, snakes.Count);

        if (index1 != index2)
        {
            Vector3 tempPosition = snakes[index1].transform.position;
            snakes[index1].transform.position = snakes[index2].transform.position;
            snakes[index2].transform.position = tempPosition;
        }
    }

    internal void AddNewSnake()
    {
        if (!SnakeConfigManager.instance.isLoad)
            SnakeConfigManager.instance.LoadSnakeConfig();
        var config = SnakeConfigManager.instance.snakeConfigs[UnityEngine.Random.Range(0, SnakeConfigManager.instance.snakeConfigs.Count)];
        var prefab = Resources.Load<GameObject>("Prefabs/SnakePrefab");
        var SnakePrefabGo = Instantiate(prefab, transform);
        Snake snake = SnakePrefabGo.GetComponent<Snake>();
        Sprite snakeSprite = Resources.Load<Sprite>("Sprites/" + config.appearance);
        snake.SetSprite(snakeSprite);
        snake.snakeName = config.name;
        snake.moveSpeed = config.speed;
        // 其他设置
        snake.exchangeRate = config.exchangeRate;
    }
    void ClearSnakes()
    {
        foreach (var item in snakes)
        {
            Destroy(item.gameObject);
        }
        snakes.Clear();
    }
}
