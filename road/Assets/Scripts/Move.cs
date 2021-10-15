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

        /// First position of the car.
        [SerializeField]
        private Vector3 startPosition;

        /// Start position property. 
        [SerializeField]
        public Vector3 StartPosition { get => this.startPosition; }


        /// Here we set values for vectors.
        void Start()
        {
            this.right = new Vector3(0.1F, 0, 0);
            this.left = new Vector3(-0.1F, 0, 0);
            this.forward = new Vector3(0, 0, 0.01F);
            this.back = new Vector3(0, 0, -0.01F);
            this.leftBoundary = -2.1F;
            this.rightBoundary = 2.1F;
            transform.localPosition = transform.parent.GetComponent<GameConfig>().CarStartPosition;
            this.startPosition = transform.localPosition;
        }

        /// Car controlling.
        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.A))
            {
                if ((transform.localPosition + left).x > leftBoundary)
                {
                    transform.Translate(this.left);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if ((transform.localPosition + right).x < rightBoundary)
                {
                    transform.Translate(this.right);
                }
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(this.forward);
            }
            else if (Input.GetKey(KeyCode.S))
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
        }

        public void Detected(Body body)
        {
            Debug.Log("Collided");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Police")
            {
                Debug.Log("Collision!");
            }
        }
    }
}