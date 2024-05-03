
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GeneratorNv))]
public class GeneratorNv_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GeneratorNv generator = (GeneratorNv)target;

        if (GUILayout.Button("GeneratorRoom"))
        {
            generator.GenerateRoom();
        }
        
        if (GUILayout.Button("ResetRoom"))
        {
            generator.ResetRoom();
        }
        
        if (GUILayout.Button("CreatRun"))
        {
            generator.CreatRun();
        }

        if (GUILayout.Button("ResetRun"))
        {
            generator.ResetRun();
        }
        
        if (GUILayout.Button("Generate All"))
        {
            generator.CreatRun();
            generator.GenerateRoom();
        }
    }
}