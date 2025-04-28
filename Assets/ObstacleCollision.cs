using UnityEngine;
using UnityEngine.SceneManagement;  // シーン管理を使うために必要

public class ObstacleCollision : MonoBehaviour
{
    public string playerTag = "Player";  // プレイヤーのタグ
    private bool isColliding = false;   // 衝突フラグ

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))  // プレイヤーと衝突した場合
        {
            if (!isColliding)
            {
                isColliding = true;  // 一度衝突したらフラグを立てて2度以上呼ばれないようにする

                // ゲームオーバー処理
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        // ゲームオーバーの処理
        Debug.Log("Game Over!");

        // ゲームオーバー後にシーンを再読み込み（リセット）
        // 他のゲームオーバー画面や演出を加えることができます
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 現在のシーンをリロード
    }
}
