using UnityEngine;
using System.Collections.Generic;


public class RoomGenerator : MonoBehaviour
{
    [Header("Точки углов комнаты (по порядку)")]
    public List<Transform> corners = new();

    [Header("Префаб стены")]
    public GameObject wallPrefab;

    [Header("Материал пола")]
    public Material floorMaterial;

    [Header("Родители для объектов")]
    public Transform wallsParent;
    public Transform floorParent;

    private List<GameObject> generatedWalls = new();
    private GameObject generatedFloor;

    void OnValidate()
    {
        if (corners.Count < 3 || wallPrefab == null)
            return;

        CleanupOldGeometry();
        GenerateWallsFromPrefabs();
        GenerateFloor();
    }

    void GenerateWallsFromPrefabs()
    {
        for (int i = 0; i < corners.Count; i++)
        {
            Transform a = corners[i];
            Transform b = corners[(i + 1) % corners.Count];

            if (a == null || b == null) continue;

            Vector3 dir = b.position - a.position;
            float distance = dir.magnitude;

            GameObject wall = Instantiate(wallPrefab, wallsParent);
            wall.name = $"Wall_{i}";

            // Центр между a и b
            wall.transform.position = a.position + dir / 2f;

            // Направление стены: вдоль линии a → b
            wall.transform.rotation = Quaternion.LookRotation(dir.normalized, Vector3.up);

            // Масштаб стены: удлиняем только Z
            Vector3 originalScale = wallPrefab.transform.localScale;
            Vector3 newScale = originalScale;
            newScale.z = distance / GetPrefabZSize(wallPrefab);
            wall.transform.localScale = newScale;

            generatedWalls.Add(wall);
        }
    }

    float GetPrefabZSize(GameObject prefab)
    {
        // Получаем размер по Z из bounds
        MeshFilter mf = prefab.GetComponentInChildren<MeshFilter>();
        if (mf == null) return 1f;
        return mf.sharedMesh.bounds.size.z * prefab.transform.localScale.z;
    }

    void GenerateFloor()
    {
        Vector3[] floorVerts = new Vector3[corners.Count];
        for (int i = 0; i < corners.Count; i++)
        {
            floorVerts[i] = corners[i].position;
        }

        // Триангуляция через центр (выпуклый полигон)
        List<int> triangles = new();
        Vector3 center = Vector3.zero;
        foreach (var v in floorVerts) center += v;
        center /= floorVerts.Length;

        int centerIndex = floorVerts.Length;
        List<Vector3> allVerts = new(floorVerts) { center };

        for (int i = 0; i < floorVerts.Length; i++)
        {
            int next = (i + 1) % floorVerts.Length;
            triangles.Add(i);
            triangles.Add(next);
            triangles.Add(centerIndex);
        }

        GameObject floor = new GameObject("Floor");
        floor.transform.SetParent(floorParent, false);

        Mesh mesh = new Mesh();
        mesh.vertices = allVerts.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

        var mf = floor.AddComponent<MeshFilter>();
        mf.sharedMesh = mesh;

        var mr = floor.AddComponent<MeshRenderer>();
        mr.sharedMaterial = floorMaterial;

        generatedFloor = floor;
    }

    void CleanupOldGeometry()
    {
        foreach (GameObject wall in generatedWalls)
        {
            if (wall != null)
                DestroyImmediate(wall);
        }
        generatedWalls.Clear();

        if (generatedFloor != null)
            DestroyImmediate(generatedFloor);
    }
}
