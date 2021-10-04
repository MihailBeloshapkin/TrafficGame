using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 direction = new Vector3(5, 0, 0);
    public Vector3 right;
    public Vector3 left;

    // Start is called before the first frame update
    void Start()
    {
        this.right = new Vector3(0.1F, 0, 0);
        this.left = new Vector3(-0.1F, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(this.left);
            Debug.Log("Space key was pressed.");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Translate(this.right);
            Debug.Log("Space key was released.");
        }
    }
}
