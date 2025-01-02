using System.Collections.Generic;
using System.Threading.Tasks;

public static class ConfigData
{
    public static bool isLoad = false;
    public static List<LevelConfig> levelConfigs = new List<LevelConfig>();
    public static List<ItemConfig> itemConfigs = new List<ItemConfig>();
    public static List<SnakeConfig> snakeConfigs = new List<SnakeConfig>();
    public static async Task LoadConfigsAsync()
    {
        if (isLoad)
            return;
        levelConfigs = await JsonUtil.DeserializeJsonToObjectAsync<LevelConfig>("levelConfig.json");
        itemConfigs = await JsonUtil.DeserializeJsonToObjectAsync<ItemConfig>("itemConfig.json");
        snakeConfigs = await JsonUtil.DeserializeJsonToObjectAsync<SnakeConfig>("snakeConfig.json");
        isLoad = true;
    }
}
