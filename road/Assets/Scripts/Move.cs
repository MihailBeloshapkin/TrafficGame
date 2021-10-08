using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 direction = new Vector3(5, 0, 0);
    
    private Vector3 right;
    private Vector3 left;
    private Vector3 forward;
    private Vector3 back;
    private float leftBoundary;
    private float rightBoundary;


    // Start is called before the first frame update
    void Start()
    {
        this.right = new Vector3(0.1F, 0, 0);
        this.left = new Vector3(-0.1F, 0, 0);
        this.forward = new Vector3(0, 0, 0.1F);
        this.back = new Vector3(0, 0, -0.1F);
        this.leftBoundary = -2.1F;
        this.rightBoundary = 2.1F;
    }

    // Update is called once per frame
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
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(this.back);
        }
    }
}
