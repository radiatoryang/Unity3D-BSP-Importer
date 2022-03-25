using UnityEditor;
using UnityEngine;
using BSPImporter;

namespace BSPImporter.Editor {

    [CustomPropertyDrawer(typeof(BSPLoader.Settings))]
    public class BspSettingsDrawer : PropertyDrawer
    {
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Calculate rects
            var rect = new Rect(position.x + 90, position.y, position.width - 90, position.height);
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("meshCombineOptions"), new GUIContent("Mesh combining", "Options for combining meshes. Per entity gives the cleanest hierarchy but may corrupt meshes with too many vertices."));

            rect.y += rect.height;            
            EditorGUI.PropertyField(rect, property.FindPropertyRelative("curveTessellationLevel"), new GUIContent("Curve detail", "Number of triangles used to tessellate curves. Higher values give smoother curves with exponentially more vertices."));

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }

}