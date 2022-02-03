using System;
using UnityEngine;

public class Player2Controls : MonoBehaviour
{
    [SerializeField] private Pong script;

    private float Limit;
    private Rigidbody2D rb;
    private Vector3 player2StartPos;

    private void Start()
    {
        Limit = Screen.width / 2f;
        rb = GetComponent<Rigidbody2D>();
        player2StartPos = transform.position;
    }
    //TODO : Сделать противника медленнее
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).position.x >= Limit)
            {
                Vector2 pos = Input.GetTouch(0).position;
                rb.MovePosition(new Vector3(player2StartPos.x, pos.y, 226));
            }
        }
    }
}
