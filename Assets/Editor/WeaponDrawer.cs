using UnityEditor;
using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Roleplay.Weapons;

[CustomPropertyDrawer(typeof(Weapon), true)]
public class WeaponDrawer : PropertyDrawer
{
    private Dictionary<string, Type> weaponTypes;
    private string[] typeNames;
    private int selectedIndex = 0;

    public WeaponDrawer()
    {
        weaponTypes = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Weapon)))
            .ToDictionary(t => t.Name, t => t);

        typeNames = weaponTypes.Keys.ToArray();
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        Rect popupRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        selectedIndex = EditorGUI.Popup(popupRect, "Weapon Type", selectedIndex, typeNames);

        if (GUI.changed && property.managedReferenceValue?.GetType().Name != typeNames[selectedIndex])
        {
            property.managedReferenceValue = Activator.CreateInstance(weaponTypes[typeNames[selectedIndex]]);
            property.serializedObject.ApplyModifiedProperties();
        }

        EditorGUI.PropertyField(position, property, true);
        EditorGUI.EndProperty();
    }
}
