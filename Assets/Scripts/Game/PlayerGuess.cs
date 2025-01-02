using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetMouseButtonDown(0) && GameManager.instance.isGaming == true)  // 左键点击（或触摸屏幕）
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
        int level = PlayerData.GetInt(PlayerData.LevelId, 1);
        LevelConfig levelConfig = ConfigData.levelConfigs.Find(l => l.level == level);
        SnakeConfig snakeConfig = ConfigData.snakeConfigs.Find(l => l.id == guessedSnake.snakeId);
        int curSnakeId = guessedSnake.snakeId;
        string playerGuess = guessedSnake.snakeName;
        string correctAnswer = "CuteSnake";  // 假设正确的答案是蛇2，实际可以从动态生成的蛇名称中获取
        GameManager.instance.isGaming = false;
        if (levelConfig.levelAns == 0 || levelConfig.levelAns == curSnakeId)
        {

            // guessResultText.GetComponent<UnityEngine.UI.Text>().text = "猜对了！";
            // 给玩家奖励或者改变游戏状态
            Tools.ShowConfirm("恭喜过关,请领取这条独一无二的蛇作为你今后冒险的伙伴", () =>
            {
                GameManager.instance.CompleteLevel();
                Tools.ShowReward(snakeConfig.name, "Sprites/" + snakeConfig.appearance, () =>
                     {
                         snakeManager.ClearSnakes();
                         if (level >= 10)
                         {
                             Tools.ShowConfirm("恭喜全部通关,请返回首页参加pk吧,点击确认立即返回", () =>
                             {
                                 SceneManager.LoadScene("Arcade");
                             }, () =>
                             {
                                 SceneManager.LoadScene("Arcade");
                             });
                         }
                         else
                             LevelManager.instance.LoadLevel(level + 1);

                     });
            }, () =>
            {
                Tools.ShowReward(snakeConfig.name, "Sprites/" + snakeConfig.appearance, () =>
                    {
                        snakeManager.ClearSnakes();
                        if (level >= 10)
                        {

                        }
                        else
                            LevelManager.instance.LoadLevel(level + 1);

                    });
            });

        }
        else
        {
            // Tools.ShowTip("猜错了");
            Tools.ShowConfirm("猜错了,再试一次吧!", () =>
            {
                snakeManager.ClearSnakes();
                LevelManager.instance.LoadLevel(level);
            });
            // guessResultText.GetComponent<UnityEngine.UI.Text>().text = "猜错了！";
            // 提供重试或返回选项
        }
    }
}
