using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraCorrection))]
public class CorrectionGUI : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CameraCorrection corr = (CameraCorrection)target;
        if (GUILayout.Button("Correct Resolution"))
        {
            corr.CorrectCamera();
        }
    }
}
