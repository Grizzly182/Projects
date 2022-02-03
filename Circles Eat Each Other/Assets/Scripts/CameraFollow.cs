using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera _cam;
    private void Start()
    {
        _cam = Camera.main;
    }
    private void LateUpdate()
    {
        _cam.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
