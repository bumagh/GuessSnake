using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    public List<Snake> snakes;  // 存储所有蛇的列表
    public float exchangeInterval = 2f;  // 交换蛇的时间间隔
    private float exchangeTimer;

    void Start()
    {
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
}
