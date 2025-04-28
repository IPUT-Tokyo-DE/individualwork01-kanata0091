using UnityEngine;

public class ObstacleFall : MonoBehaviour
{
    public float fallSpeed = 1f; // �����̗������x
    private float acceleration = 0.1f; // �������x�̉����l

    void Update()
    {
        // ��������
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // �������x������
        fallSpeed += acceleration * Time.deltaTime;
    }

    public void InitializeFall()
    {
        // �K�v�ȏ�����������΂����ɒǉ�
        fallSpeed = Random.Range(1f, 3f); // �����̑��x�̓����_���ɐݒ�
    }
}
