using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public static class RandomColorGenerator
{
    public static Color[] colors =
    {
        Color.yellow, Color.red, Color.green, Color.blue, Color.cyan, Color.gray, Color.magenta
    };
    static System.Random rand = new System.Random();

    public static Color GenerateRandomColor(this SpriteRenderer _spriteRenderer)
    {
        return _spriteRenderer.color = Random.ColorHSV();
    }

    public static Color GenerateRandomColor(this SpriteRenderer _spriteRenderer, Color[] colors)
    {
        return _spriteRenderer.color = (Color)colors.GetValue(rand.Next(0, colors.Length));
    }
}
