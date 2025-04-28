using UnityEngine;

public class ExplodingSquare : MonoBehaviour
{
    public float explosionTime = 3f;  // �����܂ł̎���
    public GameObject explosionEffect; // �����G�t�F�N�g��Prefab

    private void Start()
    {
        // �����̒x��
        Invoke(nameof(Explode), explosionTime);
    }

    void Explode()
    {
        // �����G�t�F�N�g�𐶐�
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // ���̎O�p���g�̐F���擾
        Color myColor = GetComponent<SpriteRenderer>().color;

        // �����G�t�F�N�g�̃p�[�e�B�N���V�X�e���ɐF���Z�b�g
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            var main = ps.main;
            main.startColor = myColor;
        }

        // �������g���폜
        Destroy(gameObject);
    }
}
