using UnityEngine;

public class PlayerGuess : MonoBehaviour
{
    public SnakeManager snakeManager;  // 蛇管理器
    public GameObject guessResultText;  // 显示猜测结果的文本

    private void Update()
    {
        HandleTouchInput();
    }

    // 处理玩家的触摸输入
    void HandleTouchInput()
    {
        if (Input.GetMouseButtonDown(0))  // 左键点击（或触摸屏幕）
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPosition.z = 0;  // 保持z轴为0，因为游戏是2D的
            // 检查点击的物体
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Snake clickedSnake = hit.collider.transform.parent.GetComponent<Snake>();
                if (clickedSnake != null)
                {
                    CheckGuess(clickedSnake);
                    clickedSnake.HideSnake(false);
                }
            }
        }
    }

    // 检查玩家的猜测
    void CheckGuess(Snake guessedSnake)
    {
        string playerGuess = guessedSnake.snakeName;
        string correctAnswer = "CuteSnake";  // 假设正确的答案是蛇2，实际可以从动态生成的蛇名称中获取

        if (playerGuess == correctAnswer)
        {
            guessResultText.GetComponent<UnityEngine.UI.Text>().text = "猜对了！";
            // 给玩家奖励或者改变游戏状态
            GameManager.instance.CompleteLevel();
        }
        else
        {
            guessResultText.GetComponent<UnityEngine.UI.Text>().text = "猜错了！";
            // 提供重试或返回选项
        }
    }
}
