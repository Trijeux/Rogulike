using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SelectRoom))]
public class SelectRoom_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SelectRoom generator = (SelectRoom)target;

        if (GUILayout.Button("Test"))
        {
            generator.Test();
        }
    }
}