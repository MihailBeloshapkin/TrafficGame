using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    // Current speed.
    [SerializeField] private Vector3 speed;

    [SerializeField] private Vector3 instantSpeed;

    [SerializeField] private Vector3 startSpeed;

    // Position which car starts with.
    [SerializeField] private Vector3 carStartPosition;

    [SerializeField] private bool acceleration;

    [SerializeField] private float maxSpeed;

    [SerializeField] private Vector3 reducer;

    [SerializeField] private int health;

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
        this.startSpeed = this.instantSpeed;
        this.maxSpeed = -0.9F;
        this.reducer = new Vector3(0, 0, 0.03F);
        this.health = 3;
        //    StartCoroutine(SpeedCoroutine());
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        this.Acceleration();
    }

    /// <summary>
    /// Changes speed. 
    /// </summary>
    IEnumerator SpeedCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0F);
            this.speed *= 1.1F;
        }
    }

    /// <summary>
    /// Manages car acceleration.
    /// </summary>
    private void Acceleration()
    {
        if (Input.GetKey(KeyCode.W) && !this.acceleration) 
        {
            acceleration = true;
        }
        if (!Input.GetKey(KeyCode.W) && this.acceleration)
        {
            acceleration = false;
        }
        if (acceleration && this.instantSpeed.z > this.maxSpeed)
            this.instantSpeed -= new Vector3(0, 0, 0.02F) * Time.deltaTime;
        if (!acceleration)
        {
            this.instantSpeed = this.startSpeed;
        } //  && (float)System.Math.Abs(this.instantSpeed.z - this.startSpeed.z) > 0.1F
    }

    public void Damage()
    {
        Debug.Log("Damage!");
    }
}
