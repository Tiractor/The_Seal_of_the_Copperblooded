#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;

public class ScriptTemplateGenerator
{
    [MenuItem("Assets/Create/Core/Component", false, 80)]
    public static void CreateWeaponComponent()
    {
        CreateScriptFromTemplate("Component", "Assets/Scripts/Templates/ComponentTemplate.txt");
    }

    [MenuItem("Assets/Create/Core/ComponentSystem", false, 81)]
    public static void CreateComponentSystem()
    {
        CreateScriptFromTemplate("ComponentSystem", "Assets/Scripts/Templates/ComponentSystem.txt");
    }
    [MenuItem("Assets/Create/Core/Effect", false, 82)]
    public static void CreateEffect()
    {
        CreateScriptFromTemplate("Effect", "Assets/Scripts/Templates/EntityEffect.txt");
    }
    private static void CreateScriptFromTemplate(string defaultFileName, string templatePath)
    {
        string folderPath = GetActiveFolderPath();
        string fullPath = Path.Combine(folderPath, defaultFileName);
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, fullPath);
    }

    private static string GetActiveFolderPath()
    {
        Object obj = Selection.activeObject;
        if (obj == null)
            return "Assets";

        string path = AssetDatabase.GetAssetPath(obj);
        if (string.IsNullOrEmpty(path))
            return "Assets";

        if (Directory.Exists(path))
            return path;

        return Path.GetDirectoryName(path);
    }
}
#endif