using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Traffic;

namespace Traffic
{
    /// <summary>
    /// Script for plat.
    /// </summary>
    public class Plat : OnRoadObject
    {
        [SerializeField]
        private Vector3 startPosition;

        [SerializeField]
        private Vector3 speed;

        public override Vector3 Speed
        {
            get => speed;
            set => this.speed = value;
        }

        public override Vector3 StartPosition 
        { 
            get => this.startPosition;
            set
            { 
                this.startPosition = value;
                transform.localPosition = startPosition;
            }
        }

        // Start.
        public override void Start()
        {
            this.startPosition = transform.localPosition;
        }

        // Fixed update.
        public override void FixedUpdate() {
            Move();
        }

        // Move.
        public override void Move()
        {
            if (this.speed.z > 0)
            {
                throw new System.ArgumentException("Z component of speed value for plat should be negative");
            }
            transform.Translate(this.speed);
        }
    }
}
