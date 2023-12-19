using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SCR_utils.custom_attributes.ReadOnlyAttribute))]
public class ReadInspectorDrawer : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label);
        GUI.enabled = true;
    }
}
public class TagSelectAttribute : PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label);
        GUI.enabled = true;
    }
}
