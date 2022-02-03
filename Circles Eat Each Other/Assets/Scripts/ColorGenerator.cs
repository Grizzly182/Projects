using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGenerator : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private void Awake()
    {
        _renderer = this.gameObject.GetComponent<SpriteRenderer>();
        _renderer.GenerateRandomColor(RandomColorGenerator.colors);
    }
}
