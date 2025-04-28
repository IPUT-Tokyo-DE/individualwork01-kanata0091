using UnityEngine;

public class TriangleExplosionEffect : MonoBehaviour
{
    public Material explosionMaterial; // 爆発エフェクトのマテリアル
    private Mesh mesh;

    void Start()
    {
        // 2Dの三角形のメッシュを作成
        mesh = new Mesh();

        // 三角形の頂点
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(0, 1, 0),  // 頂点1
            new Vector3(-1, -1, 0), // 頂点2
            new Vector3(1, -1, 0), // 頂点3
        };

        // 三角形のインデックス
        int[] triangles = new int[]
        {
            0, 1, 2  // 頂点1-2-3で三角形を構成
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // 2D表示のために、Z軸を0に保ちます
        mesh.SetNormals(new Vector3[] { Vector3.forward, Vector3.forward, Vector3.forward });

        // MeshFilterコンポーネントを追加
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        // MeshRendererを追加して表示
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = explosionMaterial; // 指定されたマテリアルを適用

        // 2Dで描画されるようにZ軸は0に保つ
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        // ここでエフェクトの動きを設定することができます（爆発の動きなど）
        Destroy(gameObject, 2f); // 2秒後にオブジェクトを削除
    }
}
