using System.Collections.Generic;
using System.Linq;
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
        int snakeCounts = ConfigData.snakeConfigs.Count;
        Vector3 pos1 = new Vector3(-1.71f, 3.74f, 0);//-1.71,0,1.87
        Vector3 pos2 = new Vector3(0, 3.74f, 0);//-1.71,0,1.87
        Vector3 pos3 = new Vector3(1.87f, 3.74f, 0);//-1.71,0,1.87
        if (levelConfig.level == 1)
        {
            for (int i = 0; i < ConfigData.snakeConfigs.Count; i++)
            {
                var config = ConfigData.snakeConfigs[i];
                AddSnake(levelConfig, new Vector3(pos1.x / 2 + i % 3 * 1.4f, 3.74f - i / 3 * 1.9f, 0), config);
            }
        }
        else
        {
            List<Vector3> positions = new List<Vector3>() { pos1, pos2, pos3 };
            RandomSwap.RandomSwapPositions(ref positions);
            var snakeIds = levelConfig.snakeIds.Split("|");
            if (levelConfig.snakeCount == 2)
            {
                int selectId = 1;
                if (snakeIds.Length == 2)
                {
                    selectId = int.Parse(snakeIds[0]);
                    int excludeIndex = ConfigData.snakeConfigs.FindIndex(s => s.id == selectId);
                    var config0 = ConfigData.snakeConfigs.Find(ele => ele.id == selectId);
                    var config1 = RandomSelector.RandomSelectExclude(ConfigData.snakeConfigs, new List<int>() { excludeIndex });
                    AddSnake(levelConfig, positions[0], config0);
                    AddSnake(levelConfig, positions[2], config1);
                }
            }
            else if (levelConfig.snakeCount == 3)
            {
                List<int> selectIds = new List<int>();
                List<int> excludeIdxs = new List<int>();
                if (snakeIds.Length == 3)
                {
                    selectIds.Add(int.Parse(snakeIds[0]));
                    SnakeConfig config1, config2;
                    int excludeIndex1 = ConfigData.snakeConfigs.FindIndex(s => s.id == int.Parse(snakeIds[0]));
                    excludeIdxs.Add(excludeIndex1);
                    var config0 = ConfigData.snakeConfigs.Find(ele => ele.id == int.Parse(snakeIds[0]));
                    if (int.Parse(snakeIds[1]) == 0)
                        config1 = RandomSelector.RandomSelectExclude(ConfigData.snakeConfigs, excludeIdxs);
                    else
                        config1 = ConfigData.snakeConfigs.Find(ele => ele.id == int.Parse(snakeIds[1]));
                    int excludeIndex2 = ConfigData.snakeConfigs.FindIndex(s => s.id == config1.id);
                    excludeIdxs.Add(excludeIndex2);
                    if (int.Parse(snakeIds[2]) == 0)
                        config2 = RandomSelector.RandomSelectExclude(ConfigData.snakeConfigs, excludeIdxs);
                    else
                        config2 = ConfigData.snakeConfigs.Find(ele => ele.id == int.Parse(snakeIds[1]));
                    AddSnake(levelConfig, positions[0], config0);
                    AddSnake(levelConfig, positions[1], config1);
                    AddSnake(levelConfig, positions[2], config2);
                }
            }

        }


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
