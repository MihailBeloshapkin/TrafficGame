using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    public abstract class OnRoadObject : MonoBehaviour
    {
        // Start position of the object.
        public abstract Vector3 StartPosition { get; }

        /*public abstract void CurrentPosition { get; }

        private abstract float Speed { get; }
        */

        // Move.
        public abstract void Start();
        
        public abstract void FixedUpdate();

        public abstract void Move();
    }
}
