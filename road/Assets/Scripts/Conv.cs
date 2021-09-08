using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conv : MonoBehaviour
{
    public List<GameObject> Plates; 

    public Vector3 platformDirection = new Vector3(0, 5, 0);

    
    public GameObject lastPlate;

    // Start is called before the first frame update
    void Start()
    {
        int iter = 0;
        foreach (var plat in Plates)
        {
            plat.transform.localPosition += new Vector3(0, 0, iter * 5);
            iter++;
        }
        lastPlate = Plates[0];
    }

    // Updates.
    void FixedUpdate()
    {
        Move();
        TransformPlates();
    }

    
    
    private void TransformPlates()
    {
        foreach (var plate in Plates)
        {
            if (plate.transform.localPosition.z < Camera.main.transform.position.z)
            {
                plate.transform.localPosition += new Vector3(0, 0, Plates.Count * 5);
            }
        }
    }

    private void Move()
    {
        foreach (var plat in Plates)
        {
            plat.transform.localPosition += platformDirection;   
        }
    }
}
