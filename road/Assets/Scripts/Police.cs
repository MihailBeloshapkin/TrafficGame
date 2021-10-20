using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    /// <summary>
    /// Police car script.
    /// </summary>
    public class Police : OnRoadObject
    {
        [SerializeField]
        private Vector3 speed;

        [SerializeField]
        private Vector3 startPosition;

        [SerializeField]
        private GameConfig state;

        [SerializeField]
        private int id;

        private float xTarget;

        private bool changeLine;

        // Speed of vehicle.
        public override Vector3 Speed
        {
            get => this.speed;
            set => this.speed = value;
        }

        // Start position.
        public override Vector3 StartPosition
        {
            get => this.startPosition;
            set 
            { 
                this.startPosition = value;
                transform.localPosition = startPosition;
            }

        }

        // Referes to gameconfig to have an access to an instant speed.
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

        // Start is called before the first frame update
        public override void Start() {
            this.changeLine = false;
        }

        // Update is called once per frame
        public override void FixedUpdate() {
            if (this.changeLine && xTarget < transform.localPosition.x)
            {
                transform.Translate(new Vector3(0, 0, -0.02F));
            }
            if (this.changeLine && xTarget > transform.localPosition.x)
            {
                transform.Translate(new Vector3(0, 0, 0.02F));
            }
            if (this.changeLine && System.Math.Abs(transform.localPosition.x - xTarget) < 0.05)
            {
                this.changeLine = false;
            }

            Move();
        }

        public override void Move()
        {
            var convSpeed = this.state.InstantSpeed;
            transform.Translate(convSpeed + this.speed);
        }

        public void ChangeLine(float xPosition)
        {
            this.changeLine = true;
            this.xTarget = xPosition;
        }
    }
}