using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraCorrection : MonoBehaviour
{
    public void CorrectCamera()
    {
        Camera cam = Camera.main;
        cam.orthographicSize = cam.pixelHeight / 2f;

        cam.rect = new Rect(new Vector2(0, 0),
                           new Vector2(Screen.width, Screen.height));

        cam.transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
    }
}