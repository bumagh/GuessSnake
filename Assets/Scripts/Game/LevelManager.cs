using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public SnakeManager snakeManager;  // 控制蛇的管理器
    public float difficultyIncreaseInterval = 10f;  // 每10秒增加难度
    private float difficultyTimer;
    private int currentLevel = 1;

    void Update()
    {
        difficultyTimer += Time.deltaTime;
        if (difficultyTimer >= difficultyIncreaseInterval)
        {
            IncreaseDifficulty();
            difficultyTimer = 0;
        }
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
            snakeManager.AddNewSnake();
        }
    }
}
