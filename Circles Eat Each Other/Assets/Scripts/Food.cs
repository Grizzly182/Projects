using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Food : MonoBehaviour, IConsumable
{
    public FoodType Type;
    public float Saturation
    {
        
        get {
            return Type switch
            {
                FoodType.Bot => transform.localScale.x / 2,
                FoodType.Player => transform.localScale.x / 2,
                FoodType.Food => 1f,
                _ => 5f,
            };
        }
        set { }
    }

    public void Consume(Food food)  {}
}
