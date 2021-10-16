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

        [SerializeField]
        private GameConfig state;

        [SerializeField]
        private int id;

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

        public override GameConfig State
        {
            get => this.state;
            set => this.state = value;
        }

        public override int Id
        {
            get => this.id;
            set => this.id = value;
        }

        /*
        public Plat(int id, Vector3 startPosition, Vector3 speed, GameConfig state)
        {
            this.id = id;
            this.startPosition = startPosition;
            this.speed = new Vector3(0, 0, 0);
            this.state = state;
        }*/

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
