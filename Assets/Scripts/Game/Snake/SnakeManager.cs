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
        // exchangeTimer -= Time.deltaTime;
        // if (exchangeTimer <= 0)
        // {
        //     ExchangeSnakePositions();
        //     exchangeTimer = exchangeInterval;  // 重置交换时间
        // }
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

    internal void AddNewSnake(LevelConfig levelConfig)
    {
        if (!SnakeConfigManager.instance.isLoad)
            SnakeConfigManager.instance.LoadSnakeConfig();
        Vector3 pos1 = new Vector3(-1.71f, 3.74f, 0);//-1.71,0,1.87
        Vector3 pos2 = new Vector3(0, 3.74f, 0);//-1.71,0,1.87
        Vector3 pos3 = new Vector3(1.87f, 3.74f, 0);//-1.71,0,1.87
        if (levelConfig.level == 1)
        {
            for (int i = 0; i < SnakeConfigManager.instance.snakeConfigs.Count; i++)
            {
                var config = SnakeConfigManager.instance.snakeConfigs[i];
                AddSnake(levelConfig, new Vector3(pos1.x + i % 3 * 1.4f, 3.74f - i / 3 * 1.9f, 0), config);
            }
        }
        // for (int i = 0; i < count; i++)
        // {

        // }

    }
    public void AddSnake(LevelConfig levelConfig, Vector3 pos, SnakeConfig config)
    {
        var prefab = Resources.Load<GameObject>("Prefabs/SnakePrefab");
        var SnakePrefabGo = Instantiate(prefab, transform);
        SnakePrefabGo.transform.position = pos;
        Snake snake = SnakePrefabGo.GetComponent<Snake>();
        Sprite snakeSprite = Resources.Load<Sprite>("Sprites/" + config.appearance);
        snake.SetSprite(snakeSprite);
        snake.snakeName = config.name;
        snake.snakeId = config.id;
        snake.moveSpeed = config.speed * levelConfig.snakeSpeed;
        // 其他设置
        snakes.Add(snake);
    }
    public void ClearSnakes()
    {
        foreach (var item in snakes)
        {
            Destroy(item.gameObject);
        }
        snakes.Clear();
    }
}
