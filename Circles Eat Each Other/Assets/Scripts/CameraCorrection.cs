using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraCorrection : MonoBehaviour
{
    private Camera cam;
    /*
    public void CorrectCamera()
    {
        Camera cam = Camera.main;
        cam.orthographicSize = cam.pixelHeight / 2f;

        cam.rect = new Rect(Vector2.zero,
                           new Vector2(Screen.width, Screen.height));

        cam.transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
    }*/
    public void Start()
    {
        cam = Camera.main;
    }

    public void ResizeCamera(Transform player)
    {
        cam.orthographicSize = 200 + player.localScale.x;
    }
}