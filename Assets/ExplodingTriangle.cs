using UnityEngine;

public class ExplodingTriangle : MonoBehaviour
{
    public float explosionTime = 3f;  // 爆発までの時間
    public GameObject explosionEffect; // 爆発エフェクトのPrefab

    private void Start()
    {
        // 爆発の遅延
        Invoke(nameof(Explode), explosionTime);
    }

    void Explode()
    {
        // 爆発エフェクトを生成
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // この三角自身の色を取得
        Color myColor = GetComponent<SpriteRenderer>().color;

        // 爆発エフェクトのパーティクルシステムに色をセット
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            var main = ps.main;
            main.startColor = myColor;
        }

        // 自分自身を削除
        Destroy(gameObject);
    }
}
