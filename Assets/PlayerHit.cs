using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ��Q���ɓ��������烊�X�^�[�g
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
