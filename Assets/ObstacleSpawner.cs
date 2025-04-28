using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // 障害物のプレハブ（四角と三角）
    public Camera mainCamera;            // メインカメラ
    public float spawnInterval = 3f;     // スポーン間隔

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f; // タイマーリセット
        }
    }

    void SpawnObstacle()
    {
        // カメラの画角内でランダムに位置を決める
        float screenWidth = mainCamera.orthographicSize * mainCamera.aspect;
        float screenHeight = mainCamera.orthographicSize;

        // 横軸と縦軸のランダム位置
        float randomX = Random.Range(-screenWidth, screenWidth);
        float randomY = screenHeight + 1f; // カメラ画角の外からスポーン（上から）

        // 障害物をランダムに選ぶ
        int index = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacle = Instantiate(obstaclePrefabs[index], new Vector3(randomX, randomY, 0), Quaternion.identity);

        // 各障害物に爆発スクリプトをアタッチ
        if (obstacle.CompareTag("Square"))
        {
            // 四角（爆発する障害物）に爆発スクリプトをアタッチ
            ExplodingSquare explodingSquare = obstacle.AddComponent<ExplodingSquare>();
            explodingSquare.explosionTime = 3f;  // 3秒後に爆発

            // 落下設定
            obstacle.AddComponent<ObstacleFall>();  // ObstacleFall スクリプトを追加
            obstacle.GetComponent<ObstacleFall>().InitializeFall();  // 落下速度をランダムに設定
        }
        else if (obstacle.CompareTag("Triangle"))
        {
            // 三角（爆発する障害物）に爆発スクリプトをアタッチ
            ExplodingTriangle explodingTriangle = obstacle.AddComponent<ExplodingTriangle>();
            explodingTriangle.explosionTime = 3f;  // 3秒後に爆発

            // 落下設定
            obstacle.AddComponent<ObstacleFall>();  // ObstacleFall スクリプトを追加
            obstacle.GetComponent<ObstacleFall>().InitializeFall();  // 落下速度をランダムに設定
        }
    }
}
