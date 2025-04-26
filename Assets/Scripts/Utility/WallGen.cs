using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class WallGen : MonoBehaviour
{
    public enum Axis { X, Y, Z }

    public Axis Direction = Axis.X;
    public float Delta = 1f;
    public bool Fixed = false;
    public GameObject Prefab;
    public GameObject Ender;
    public int Count = 5;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (gameObject.scene.name == null || Fixed) return;
        // Откладываем выполнение до конца текущего кадра
        EditorApplication.delayCall += () =>
        {
            if (this == null || Prefab == null) return;
            if (!Application.isPlaying)
            {
                Generate();
            }
        };
    }

    private void Generate()
    {
        // Удаление старых потомков
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Object.DestroyImmediate(transform.GetChild(i).gameObject);
        }

        Vector3 offset = GetDirectionVector() * Delta;
        var temp = Prefab;
        for (int i = 0; i < Count; i++)
        {
            if (Count - 1 == i && Ender != null) temp = Ender;
            GameObject go = (GameObject)PrefabUtility.InstantiatePrefab(temp, transform);
            go.transform.localPosition = offset * i;
        }
    }
#endif

    private Vector3 GetDirectionVector()
    {
        return Direction switch
        {
            Axis.X => Vector3.right,
            Axis.Y => Vector3.up,
            Axis.Z => Vector3.forward,
            _ => Vector3.right
        };
    }
}
