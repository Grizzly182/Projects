using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBall
{
    //TODO: ������� ���� � ������� �������� ��� � ��������� ���� ��� ������
    //public string Nickname { get; set; }
    public Vector3 StartSize { get; set; }
}

public interface IConsumable
{
    public float Saturation { get; set; }
    public void Consume(Food food);
}

public interface IMovable
{
    public void Move();
}