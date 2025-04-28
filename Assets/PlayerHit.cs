using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 障害物に当たったらリスタート
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
