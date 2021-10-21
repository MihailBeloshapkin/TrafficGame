using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    /// <summary>
    /// Current game state.
    /// </summary>
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

        [SerializeField] private GameObject healthManager;

        [SerializeField] private GameObject StartAndPause;

        public int accDirection;

        /// <summary>
        /// Car start position.
        /// </summary>
        public Vector3 CarStartPosition { get => this.carStartPosition; }

       
        /// <summary>
        /// INstant speed value.
        /// </summary>
        public Vector3 InstantSpeed { get => this.instantSpeed; }

        public int Health { get => this.health; set => this.health = 4; }

        // Start is called before the first frame update
        void Start()
        {
            //    this.carStartPosition = new Vector3(0, 0.2F, -0.9F);
            this.acceleration = false;
            this.backAcceleration = false;
            this.accDirection = 0;
            this.startSpeed = this.instantSpeed;
            this.maxSpeed = -0.5F;
            this.health = 4;
            //    StartCoroutine(SpeedCoroutine());
        }

        // Update is called once per frame.
        void Update()
        {
            if (this.health == 0)
                health = 4;
            this.AltAcceleration();
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

        /// <summary>
        /// Gets acceleration direction. 
        /// </summary>
        public void AccelerationAxis(int InputAxis)
            => this.accDirection = InputAxis;
        
        /// <summary>
        /// Acceleration controlled with buttons.
        /// </summary>
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

        /// <summary>
        /// Manages damage.
        /// </summary>
        public void Damage(int damage)
        {
            this.health--;
            this.healthManager.GetComponent<HealthManager>().Damage(1);
            if (health == 0)
            {
                this.StartAndPause.GetComponent<PauseScript>().Finish();
                this.instantSpeed = this.startSpeed;
                this.healthManager.GetComponent<HealthManager>().Damage(-4);
            }
        }
    }
}