using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SnakeManager snakeManager;
    public PlayerGuess playerGuess;
    public GameObject levelCompletePanel;  // 完成关卡后的UI面板
    public static GameManager instance;
    private int currentLevel = 1;
    public bool isGaming = false;
    void Start()
    {
        instance = this;
    }

    public void CompleteLevel()
    {

        Tools.ShowConfirm("完成关卡,继续下一关", () =>
        {
            LoadNextLevel();
        });
    }

    void LoadNextLevel()
    {
        currentLevel++;
        // levelCompletePanel.SetActive(false);

        // 可以根据关卡数改变游戏的难度，例如增加蛇的速度或数量
        // 这里简化为直接切换蛇的位置
        snakeManager.exchangeInterval = Mathf.Max(0.5f, snakeManager.exchangeInterval - 0.2f);
    }
}
