using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 direction;
    
    /// Right direction. 
    private Vector3 right;

    /// Left direction.
    private Vector3 left;

    /// Forward direction.
    private Vector3 forward;

    /// Back direction.
    private Vector3 back;
    
    /// Left boundary of the road.
    private float leftBoundary;

    /// Right boundary of the road.
    private float rightBoundary;

    /// First position of the car.
    private Vector3 startPosition;


    // Here we set values for vectors.
    void Start()
    {
        this.right = new Vector3(0.1F, 0, 0);
        this.left = new Vector3(-0.1F, 0, 0);
        this.forward = new Vector3(0, 0, 0.01F);
        this.back = new Vector3(0, 0, -0.01F);
        this.leftBoundary = -2.1F;
        this.rightBoundary = 2.1F;
        this.startPosition = transform.localPosition;
    }

    // Car controlling.
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "cube")
        {
            
        }
    }
}
