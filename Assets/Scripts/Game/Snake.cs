using UnityEngine;

public class Snake : MonoBehaviour
{
    public string snakeName;  // 蛇的名字（例如 "蛇1", "蛇2" 或网络热梗）
    public Vector2 moveDirection;  // 蛇的移动方向
    public float moveSpeed = 2f;  // 蛇的移动速度

    private Vector2 startPosition;  // 初始位置

    // 初始化
    void Start()
    {
        startPosition = transform.position;
    }

    // 每帧更新蛇的位置
    void Update()
    {
        MoveSnake();
    }

    // 移动蛇
    void MoveSnake()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    // 随机改变蛇的方向（用于交换）
    public void ChangeDirection(Vector2 newDirection)
    {
        moveDirection = newDirection;
    }

    // 重置蛇的位置
    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}
