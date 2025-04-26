using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using Core.EntityStatuses;

[CustomPropertyDrawer(typeof(EntityStatus), true)]
public class StatusDrawer : PropertyDrawer
{
    private Dictionary<string, Type> classTypes;
    private string[] typeNames;
    private int selectedIndex = 0;

    public StatusDrawer()
    {
        classTypes = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(EntityStatus)))
            .ToDictionary(t => t.Name, t => t);

        typeNames = classTypes.Keys.ToArray();
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        Rect popupRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        selectedIndex = EditorGUI.Popup(popupRect," ", selectedIndex, typeNames);

        if (GUI.changed && property.managedReferenceValue?.GetType().Name != typeNames[selectedIndex])
        {
            property.managedReferenceValue = Activator.CreateInstance(classTypes[typeNames[selectedIndex]]);
            property.serializedObject.ApplyModifiedProperties();
        }

        EditorGUI.PropertyField(position, property, true);
        EditorGUI.EndProperty();
    }
}
