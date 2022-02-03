using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Bonuses : MonoBehaviour
{
    public abstract class Bonus
    {
        public enum BonusType
        {
            PlatformIncrease,
            PlatformDecrease,
            BallInCrease,
            BallDecrease
        }
        
        public abstract void ApplyBonus(float time, Vector2 size);
    }
    public interface IBonus
    {
        void ApplyBonus(float time, Vector2 size);
    }
}
