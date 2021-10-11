using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Generator : MonoBehaviour
{
    [SerializeField]
    private Move carInfo;

    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Generation()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cube.transform.localPosition.z < carInfo.StartPosition.z - 7)
        {
            cube.transform.localPosition = carInfo.StartPosition + new Vector3(UnityEngine.Random.Range(-3, 3), 0, 10);
        }
        cube.transform.localPosition += new Vector3(0, 0, -0.1F);
    }
}
