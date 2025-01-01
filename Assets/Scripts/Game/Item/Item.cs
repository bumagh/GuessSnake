using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemConfig config;

    public void Setup(ItemConfig itemConfig)
    {
        config = itemConfig;
    }

    public void Activate()
    {
        switch (config.type)
        {
            case "Hint":
                ActivateHint();
                break;
            case "Pause":
                ActivatePause();
                break;
            case "SlowMotion":
                ActivateSlowMotion();
                break;
            case "SpeedBoost":
                ActivateSpeedBoost();
                break;
            case "ClearScreen":
                ActivateClearScreen();
                break;
        }
    }

    void ActivateHint()
    {
        Debug.Log("激活提示道具！");
        // 实现提示功能
    }

    void ActivatePause()
    {
        Debug.Log("激活暂停道具！");
        Time.timeScale = 0;
        Invoke("ResumeGame", config.duration);
    }

    void ActivateSlowMotion()
    {
        Debug.Log("激活减速道具！");
        // 实现减速功能
    }

    void ActivateSpeedBoost()
    {
        Debug.Log("激活加速道具！");
        // 实现加速功能
    }

    void ActivateClearScreen()
    {
        Debug.Log("激活清屏道具！");
        // 实现清屏功能
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
