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

        public override Vector3 Speed
        {
            get => this.speed;
            set => this.speed = value;
        }

        public override Vector3 StartPosition
        {
            get => this.startPosition;
            set
            {
                this.startPosition = value;
                transform.localPosition = this.startPosition;
            }
        }

        // Start is called before the first frame update
        public override void Start() {

        }

        // Update is called once per frame
        public override void FixedUpdate() {
            Move();
        }

        public override void Move()
        {
            transform.Translate(this.speed);
        }
    }
}