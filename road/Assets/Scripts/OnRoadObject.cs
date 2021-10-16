using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    // Base properties for each object.
    public abstract class OnRoadObject : MonoBehaviour
    {
        // Start position of the object.
        public abstract Vector3 StartPosition { get; set; }

        // Speed.
        public abstract Vector3 Speed { get; set; }

        // Current config of the game.
        public abstract GameConfig State { get; set; }

        public abstract int Id { get; set; }

        // Move.
        public abstract void Start();
        
        // Fixed update.
        public abstract void FixedUpdate();

        // Move.
        public abstract void Move();
    }
}
