using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DisableOrEnableObject))]
public class  EnableMagnifierEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DisableOrEnableObject myScript = (DisableOrEnableObject)target;

        if (GUILayout.Button("Toggle Magnifier"))
        {
            myScript.MagnifierClicked();
        }

        if (GUILayout.Button("Toggle Edge Detection"))
        {
            myScript.EdgeDetectionClicked();
        }

        if (GUILayout.Button("Toggle Contrast"))
        {
            myScript.ContrastClicked();
        }

        if (GUILayout.Button("Toggle Brightness"))
        {
            myScript.BrightnessClicked();
        }
    }
}


