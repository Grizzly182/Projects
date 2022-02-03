using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public delegate void MoveStateHandler();
    public class MoveEventArgs
    {
        public Vector3 StartPosition { get; private set; }
        public Vector3 Destination { get; private set; }
        public MoveEventArgs(Vector3 start, Vector3 finish)
        {
            StartPosition = start;
            Destination = finish;
        }
    }
}
