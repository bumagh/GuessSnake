using UnityEngine;

public enum ItemType { Hint, Pause }

public class Item : MonoBehaviour
{
    public ItemType itemType;  // 道具类型
    public GameObject hintUI;  // 提示UI对象

    // 使用道具
    public void UseItem()
    {
        switch (itemType)
        {
            case ItemType.Hint:
                UseHint();
                break;
            case ItemType.Pause:
                UsePause();
                break;
        }
    }

    void UseHint()
    {
        // 显示提示UI，给玩家显示蛇的部分信息
        hintUI.SetActive(true);
    }

    void UsePause()
    {
        // 暂停游戏时间
        Time.timeScale = 0;  // 暂停游戏
        // 可以设置一个按钮来恢复游戏
    }
}
