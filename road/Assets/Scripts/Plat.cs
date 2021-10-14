using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Traffic;

namespace Traffic
{
    public class Plat : OnRoadObject
    {
        public override Vector3 StartPosition { get => this.startPosition; } 

        private Vector3 startPosition;

        [SerializeField]
        private Vector3 direction;


        public override void Start()
        {
            this.direction = new Vector3(0, 0, -0.2F);
        }

        public override void FixedUpdate() 
        {
            Move();
        }

        public override void Move()
        {
            transform.Translate(this.direction);
        }
    }

}
