using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.EntityEffects;
using System.Reflection;

[CustomPropertyDrawer(typeof(EntityEffect), true)]
public class EffectDrawer : PropertyDrawer
{
    private Dictionary<string, Type> effectTypes;
    private string[] typeNames;
    private int selectedIndex = -1;

    public EffectDrawer()
    {
        effectTypes = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttribute<HideInCustomInspector>() == null && t.IsSubclassOf(typeof(EntityEffect)))
            .ToDictionary(t => t.Name, t => t);

        typeNames = effectTypes.Keys.ToArray();
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var currentValue = property.managedReferenceValue;
        string currentTypeName = currentValue?.GetType().Name ?? "None";

        if (selectedIndex == -1 || (currentValue != null && effectTypes[typeNames[selectedIndex]] != currentValue.GetType()))
        {
            selectedIndex = Array.IndexOf(typeNames, currentTypeName);
        }
        if (selectedIndex == -1) selectedIndex = 0;

        Rect popupRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        int newIndex = EditorGUI.Popup(popupRect, "", selectedIndex, typeNames);

        if (newIndex != selectedIndex)
        {
            selectedIndex = newIndex;
            Type newType = effectTypes[typeNames[selectedIndex]];
            property.managedReferenceValue = Activator.CreateInstance(newType);
            property.serializedObject.ApplyModifiedProperties();
            property.serializedObject.Update();
        }

        if (property.managedReferenceValue != null)
        {
            SerializedProperty iterator = property.Copy();
            Rect contentPosition = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 2, position.width, position.height - EditorGUIUtility.singleLineHeight - 2);
            EditorGUI.indentLevel++;
            EditorGUI.PropertyField(contentPosition, iterator, true);
            EditorGUI.indentLevel--;
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = EditorGUIUtility.singleLineHeight + 2; 
        if (property.managedReferenceValue != null)
        {
            height += EditorGUI.GetPropertyHeight(property, true);
        }
        return height;
    }
}
