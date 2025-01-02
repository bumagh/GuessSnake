using System.Collections.Generic;
using UnityEngine;

public class RandomSelector : MonoBehaviour
{
    // 通用随机选择并排除函数
    // 通用随机选择并排除多个元素
    public static T RandomSelectExclude<T>(List<T> list, List<int> excludeList)
    {
        // 确保列表不为空
        if (list == null || list.Count == 0)
        {
            Debug.LogError("列表为空，无法进行选择！");
            return default(T);  // 返回默认值（null 或类型的默认值）
        }

        // 创建一个副本以避免修改原始列表
        List<T> remainingList = new List<T>(list);

        // 从 remainingList 中排除已选的元素
        foreach (int excludeItem in excludeList)
        {
            remainingList.RemoveAt(excludeItem);
        }

        // 如果排除后列表为空，返回默认值
        if (remainingList.Count == 0)
        {
            Debug.LogError("排除元素后列表为空，无法选择！");
            return default(T);  // 返回默认值（null 或类型的默认值）
        }

        // 从剩余的列表中随机选择一个元素
        int randomIndex = Random.Range(0, remainingList.Count);
        return remainingList[randomIndex];
    }
}