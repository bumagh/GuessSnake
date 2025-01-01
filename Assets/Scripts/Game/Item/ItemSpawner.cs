using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject hintItemPrefab;
    public GameObject pauseItemPrefab;

    public float spawnInterval = 10f;
    private float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnItem();
            spawnTimer = 0;
        }
    }

    void SpawnItem()
    {
        // 随机选择道具生成
        int randomItem = Random.Range(0, 2);
        GameObject itemPrefab = (randomItem == 0) ? hintItemPrefab : pauseItemPrefab;

        // 在屏幕上随机位置生成道具
        Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        Instantiate(itemPrefab, randomPosition, Quaternion.identity);
    }
}
