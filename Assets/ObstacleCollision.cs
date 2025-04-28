using UnityEngine;
using UnityEngine.SceneManagement;  // �V�[���Ǘ����g�����߂ɕK�v

public class ObstacleCollision : MonoBehaviour
{
    public string playerTag = "Player";  // �v���C���[�̃^�O
    private bool isColliding = false;   // �Փ˃t���O

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))  // �v���C���[�ƏՓ˂����ꍇ
        {
            if (!isColliding)
            {
                isColliding = true;  // ��x�Փ˂�����t���O�𗧂Ă�2�x�ȏ�Ă΂�Ȃ��悤�ɂ���

                // �Q�[���I�[�o�[����
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        // �Q�[���I�[�o�[�̏���
        Debug.Log("Game Over!");

        // �Q�[���I�[�o�[��ɃV�[�����ēǂݍ��݁i���Z�b�g�j
        // ���̃Q�[���I�[�o�[��ʂ≉�o�������邱�Ƃ��ł��܂�
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���݂̃V�[���������[�h
    }
}
