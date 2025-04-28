using UnityEngine;

public class TriangleExplosionEffect : MonoBehaviour
{
    public Material explosionMaterial; // �����G�t�F�N�g�̃}�e���A��
    private Mesh mesh;

    void Start()
    {
        // 2D�̎O�p�`�̃��b�V�����쐬
        mesh = new Mesh();

        // �O�p�`�̒��_
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 1, 0),  // ���_1
            new Vector3(-1, -1, 0), // ���_2
            new Vector3(1, -1, 0), // ���_3
        };

        // �O�p�`�̃C���f�b�N�X
        int[] triangles = new int[]
        {
            0, 1, 2  // ���_1-2-3�ŎO�p�`���\��
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // 2D�\���̂��߂ɁAZ����0�ɕۂ��܂�
        mesh.SetNormals(new Vector3[] { Vector3.forward, Vector3.forward, Vector3.forward });

        // MeshFilter�R���|�[�l���g��ǉ�
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        // MeshRenderer��ǉ����ĕ\��
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = explosionMaterial; // �w�肳�ꂽ�}�e���A����K�p

        // 2D�ŕ`�悳���悤��Z����0�ɕۂ�
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        // �����ŃG�t�F�N�g�̓�����ݒ肷�邱�Ƃ��ł��܂��i�����̓����Ȃǁj
        Destroy(gameObject, 2f); // 2�b��ɃI�u�W�F�N�g���폜
    }
}
