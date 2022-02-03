using System;
using System.Collections;
using UnityEngine;

//TODO: —делать врем€ действи€ бонуса дл€ всех бонусов
public class PlatformIncreaseBonus : MonoBehaviour, Bonuses.IBonus
{
    private Transform Player;
    private Vector3 Base;
    private Vector3 Target;

    private IEnumerator _resizeCoroutine;

    //private void OnDestroy()
    //{
    //    ApplyBonus(1, Target);
    //}
    private void OnTriggerEnter2D()
    {
        ApplyBonus(1, Target);
    }

    private IEnumerator ResizeCoroutine(float time)
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
        Debug.Log("end");
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
        Target = new Vector3(Base.x, Base.y * 1.5f);
        if (_resizeCoroutine != null)
        {
            StopCoroutine(_resizeCoroutine);
        }
        _resizeCoroutine = ResizeCoroutine(1);
        StartCoroutine(_resizeCoroutine);
    }
}
