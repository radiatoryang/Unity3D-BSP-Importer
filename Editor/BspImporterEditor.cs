using UnityEngine;
using UnityEditor;

#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#elif UNITY_2017_1_OR_NEWER
using UnityEditor.Experimental.AssetImporters;
#endif

using System.IO;
using BSPImporter;
using LibBSP;

namespace BSPImporter.Editor {

    [CustomEditor(typeof(BspImporter))]
    public class BspImporterEditor: ScriptedImporterEditor
    {
        public override void OnInspectorGUI()
        {
            // var colorShift = new GUIContent("Color Shift");
            var prop = serializedObject.FindProperty("settings");
            EditorGUILayout.PropertyField(prop, new GUIContent("BSP Import Settings"));

            base.ApplyRevertGUI();
        }
    }

}