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

    /// <summary>
    /// custom Unity importer that detects .BSP files in /Assets/
    /// and automatically imports them like any other 3D mesh
    /// </summary>
    [ScriptedImporter(1, "bsp")]
    public class BspImporter : ScriptedImporter
    {
        public BSPLoader.Settings settings;

        public override void OnImportAsset(AssetImportContext ctx)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // var position = JsonUtility.FromJson<Vector3>(File.ReadAllText(ctx.assetPath));

            // cube.transform.position = position;
            // cube.transform.localScale = new Vector3(m_Scale, m_Scale, m_Scale);

            // 'cube' is a GameObject and will be automatically converted into a prefab
            // (Only the 'Main Asset' is eligible to become a Prefab.)
            ctx.AddObjectToAsset("main obj", cube);
            ctx.SetMainObject(cube);

            var material = new Material(Shader.Find("Standard"));
            material.color = Color.red;

            // Assets must be assigned a unique identifier string consistent across imports
            ctx.AddObjectToAsset("my Material", material);

            // Assets that are not passed into the context as import outputs must be destroyed
            var tempMesh = new Mesh();
            DestroyImmediate(tempMesh);
        }
    }

}