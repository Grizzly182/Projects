using System;
using System.Collections;
using UnityEngine;

public class PlatformDecreaseBonus : MonoBehaviour, Bonuses.IBonus
{
    private Transform Player;
    private Vector3 Base;
    private Vector3 Target;

    private IEnumerator _resizeCoroutine;

    //private void OnDestroy()
    //{
    //    ApplyBonus(1, Target);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ApplyBonus(1, Target);
    }

    private IEnumerator ResizeCoroutine(float time, Vector2 size)
    {
        float timer = 0;
        while (timer < time)
        {
            Player.localScale = Vector3.Lerp(Base, Target, timer / time);
            yield return null;
            timer += Time.deltaTime;
        }

        Player.localScale = Target;
        _resizeCoroutine = null;
    }

    public void ApplyBonus(float time, Vector2 size)
    {
        if (BallScript.Player == null)
        {
            throw new NullReferenceException();
        }
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Player = BallScript.Player;
        Base = Player.localScale;
        Target = new Vector3(Base.x, Base.y * 0.5f);
        if (_resizeCoroutine != null)
        {
            StopCoroutine(_resizeCoroutine);
        }
        _resizeCoroutine = ResizeCoroutine(1, Target);
        StartCoroutine(_resizeCoroutine);
    }
}
