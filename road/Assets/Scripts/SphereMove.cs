using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("a"))
        {
            transform.localPosition += new Vector3(5, 0, 0);
        }
        if (Input.GetButton("b"))
        {
            transform.localPosition += new Vector3(-5, 0, 0);
        }
    }
}
