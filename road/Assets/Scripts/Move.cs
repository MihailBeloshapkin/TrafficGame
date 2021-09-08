using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 direction; 

    public Transform _rotator;

    // Start is called before the first frame update
    void Start()
    {
        _rotator = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction / 100);
    }
}
