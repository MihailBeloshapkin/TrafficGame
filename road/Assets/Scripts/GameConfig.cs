using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    [AddComponentMenu("Game Config")]
    public class GameConfig : MonoBehaviour
    {
        // Current speed.
        [SerializeField] private Vector3 speed;

        [SerializeField] private Vector3 instantSpeed;

        [SerializeField] private Vector3 startSpeed;

        // Position which car starts with.
        [SerializeField] private Vector3 carStartPosition;

        [SerializeField] private bool acceleration;

        [SerializeField] private bool backAcceleration;

        [SerializeField] private Vector3 accelerationVector;

        [SerializeField] private Vector3 backAccelerationVector;

        [SerializeField] private float maxSpeed;

        [SerializeField] private float minSpeed;

        [SerializeField] private int health;

        public int accDirection;

        /// <summary>
        /// Car start position.
        /// </summary>
        public Vector3 CarStartPosition { get => this.carStartPosition; }

        public Vector3 Speed { get => this.speed; }

        /// <summary>
        /// INstant speed value.
        /// </summary>
        public Vector3 InstantSpeed { get => this.instantSpeed; }

        // Start is called before the first frame update
        void Start()
        {
            //    this.carStartPosition = new Vector3(0, 0.2F, -0.9F);
            this.acceleration = false;
            this.backAcceleration = false;
            this.accDirection = 0;
            this.startSpeed = this.instantSpeed;
            this.maxSpeed = -0.5F;
            this.health = 3;
            //    StartCoroutine(SpeedCoroutine());
        }

        // Update is called once per frame
        void Update()
        {
            this.AltAcceleration();
        //    this.Acceleration();
        }

        /// <summary>
        /// Changes speed. 
        /// </summary>
        IEnumerator SpeedCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(10.0F);
                this.startSpeed *= 1.1F;
            }
        }

        public void AccelerationAxis(int InputAxis)
        {
            if (InputAxis == 1)
            {
                Debug.Log("Acceleration");
            }
            this.accDirection = InputAxis;
        }

        private void AltAcceleration()
        {
            if (this.accDirection == 1 && this.instantSpeed.z > this.maxSpeed)
            {
                this.instantSpeed -= new Vector3(0, 0, 0.02F) * Time.deltaTime;
            }
            if (this.accDirection == -1 && instantSpeed.z < this.startSpeed.z)
            {
                this.instantSpeed += new Vector3(0, 0, 0.08F) * Time.deltaTime;
            }
            if (this.accDirection == 0 && instantSpeed.z < this.startSpeed.z)
            {
                this.instantSpeed += new Vector3(0, 0, 0.02F) * Time.deltaTime;
            }
        }

        /// <summary>
        /// Manages car acceleration.
        /// </summary>
        private void Acceleration()
        {
            if ((Input.GetKey(KeyCode.W) && !this.acceleration))
            {
                this.backAcceleration = false;
                this.acceleration = true;
            }
            if (!Input.GetKey(KeyCode.W) && this.acceleration)
            {
                this.acceleration = false;
            }
            if (Input.GetKey(KeyCode.S) && !this.backAcceleration)
            {
                this.acceleration = false;
                this.backAcceleration = true;
            }
            if (backAcceleration && instantSpeed.z < this.startSpeed.z)
            {
                this.instantSpeed += new Vector3(0, 0, 0.08F) * Time.deltaTime;
            }
            if (acceleration && this.instantSpeed.z > this.maxSpeed)
            {
                this.instantSpeed -= new Vector3(0, 0, 0.02F) * Time.deltaTime;
            }
            if (!acceleration && instantSpeed.z < this.startSpeed.z)
            {
                this.instantSpeed += new Vector3(0, 0, 0.02F) * Time.deltaTime;
            }
        }

        public void Damage()
        {
            Debug.Log("Damage!");
        }
    }
}