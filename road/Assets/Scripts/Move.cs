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

    // Start is called before the first frame update
    void Start()
    {
        this.right = new Vector3(0.1F, 0, 0);
        this.left = new Vector3(-0.1F, 0, 0);
        this.forward = new Vector3(0, 0, 0.1F);
        this.back = new Vector3(0, 0, -0.1F);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(this.left);
            Debug.Log("Space key was pressed.");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(this.right);
            Debug.Log("Space key was released.");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(this.forward);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(this.back);
        }
    }
}
