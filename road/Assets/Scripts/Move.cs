using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Traffic
{
    /// <summary>
    /// Script that manages car movement.
    /// </summary>
    public class Move : MonoBehaviour
    {
        /// Right direction. 
        [SerializeField]
        private Vector3 right;

        /// Left direction.
        [SerializeField]
        private Vector3 left;

        /// Forward direction.
        [SerializeField]
        private Vector3 forward;

        /// Back direction.
        [SerializeField]
        private Vector3 back;

        /// Left boundary of the road.
        [SerializeField]
        private float leftBoundary;

        /// Right boundary of the road.
        [SerializeField]
        private float rightBoundary;

        [SerializeField]
        private float frontBoundary;

        [SerializeField]
        private float backBoundary;

        /// First position of the car.
        [SerializeField]
        private Vector3 startPosition;

        public int directionX;

        public int directionZ;

        /// Start position property. 
        [SerializeField]
        public Vector3 StartPosition { get => this.startPosition; }

        public Rigidbody rb;

        /// Here we set values for vectors.
        void Start()
        {
            this.rb = GetComponent<Rigidbody>();
            directionX = 0;
            directionZ = 0;


            this.right = new Vector3(1.7F, 0, 0);
            this.left = new Vector3(-1.7F, 0, 0);
            this.forward = new Vector3(0, 0, 0.01F);
            this.back = new Vector3(0, 0, -0.01F);
            this.leftBoundary = -3.8F;
            this.rightBoundary = 3.8F;
            this.frontBoundary = 0.7F;
            this.backBoundary = -0.5F;
            transform.localPosition = transform.parent.GetComponent<GameConfig>().CarStartPosition;
            this.startPosition = transform.localPosition;
        }

        /*
        void Update()
        {
            if (Input.GetButtonDown("Button1"))
            {
                Debug.Log("Pressed");
            }
        }*/

        /// Car controlling.
        void FixedUpdate()
        {
            if (transform.localRotation != Quaternion.identity)
            {
                transform.localRotation = Quaternion.identity;
            }
            if ((Input.GetKey(KeyCode.A) || directionX == -1) && (transform.localPosition + left).x > leftBoundary)
            {
                rb.velocity = this.left;
            //    transform.Translate(this.left);   
            }
            if ((Input.GetKey(KeyCode.D) || directionX == 1) && (transform.localPosition + right).x < rightBoundary)
            {
                rb.velocity = this.right;
           //     transform.Translate(this.right);
            }
            if ((Input.GetKey(KeyCode.W) || directionZ == 1) && (transform.localPosition + forward).z < this.frontBoundary)
            {
                transform.Translate(this.forward);
            }
            else if ((Input.GetKey(KeyCode.W) || directionZ == -1) && (transform.localPosition + back).z > this.backBoundary)
            {
                transform.Translate(this.back);
            }
            else
            {
                if (transform.localPosition.z > startPosition.z)
                    transform.Translate(back);
                if (transform.localPosition.z < startPosition.z)
                    transform.Translate(forward);
            }
            if (transform.localPosition.z < Camera.main.transform.position.z)
            {
                transform.parent.GetComponent<GameConfig>().Damage();
            }
        }

        public void CarMoveX(int InputAxis)
        {
            this.directionX = InputAxis;
        }

        public void CarMoveZ(int InputAxis) => this.directionZ = InputAxis;

        /// <summary>
        /// Manages collisions.
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Police")
            {
                Debug.Log("Damage");
                transform.parent.GetComponent<GameConfig>().Damage();
            }
        }
    }
}