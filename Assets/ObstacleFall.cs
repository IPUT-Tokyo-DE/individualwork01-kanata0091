using UnityEngine;

public class ObstacleFall : MonoBehaviour
{
    public float fallSpeed = 1f; // 初期の落下速度
    private float acceleration = 0.1f; // 落下速度の加速値

    void Update()
    {
        // 落下処理
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // 落下速度を加速
        fallSpeed += acceleration * Time.deltaTime;
    }

    public void InitializeFall()
    {
        // 必要な初期化があればここに追加
        fallSpeed = Random.Range(1f, 3f); // 初期の速度はランダムに設定
    }
}
