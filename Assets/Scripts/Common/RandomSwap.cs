using UnityEngine;
using System.Collections.Generic;

public class RandomSwap : MonoBehaviour
{
    // 通用的随机交换方法
    public static void RandomSwapPositions<T>(ref List<T> list)
    {
        // 确保列表不为空
        if (list == null || list.Count < 2)
        {
            Debug.LogError("列表为空或元素少于两个，无法进行交换！");
            return;
        }

        // 随机选择两个不同的索引
        int index1 = Random.Range(0, list.Count); // 随机索引1
        int index2 = Random.Range(0, list.Count); // 随机索引2

        // 确保两个索引不同
        while (index1 == index2)
        {
            index2 = Random.Range(0, list.Count);
        }

        // 交换位置
        T temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}
