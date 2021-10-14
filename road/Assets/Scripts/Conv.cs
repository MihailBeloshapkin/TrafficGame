using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Conveer.
/// </summary>
public class Conv : MonoBehaviour
{
    /// Current plates
    public List<GameObject> Road;

    /// <summary>
    /// Bool array. 
    /// </summary>
    public bool[] isRoad;

    /// Direction. 
    public Vector3 platformDirection = new Vector3(0, 5, 0);

    public Vector3 gaz = new Vector3(0, 10, 0);

    public Vector3 breaks = new Vector3(0, 2, 0);

    public int size = 0;

    // Start is called before the first frame update
    void Start()
    {
        int iter = 0;
        int roadIndex = 0;
        isRoad = new bool[Road.Count];
        foreach (var plat in Road)
        {
/*            plat.transform.localPosition += new Vector3(0, 0, roadIndex * 5);
            roadIndex++;
*/
            if (iter % 2 == 0)
            {
                plat.transform.localPosition += new Vector3(0, 0, roadIndex * 5);
                roadIndex++;
                isRoad[iter] = true;
            }
            else
            {
                plat.transform.localPosition += new Vector3(0, -50, -50);
                isRoad[iter] = false;
            }
            iter++;
        }
        
    }

    /// <summary>
    /// Fixed update.
    /// </summary>
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) {
            Move(gaz);
        }
        if (Input.GetKey(KeyCode.S)) {
            Move(breaks);
        }
        else
        {
            Move(platformDirection);
        }

        TransformPlates();
    }

    private int Rand(int size) => UnityEngine.Random.Range(0, size);

    /// <summary>
    /// Move plates.
    /// </summary>
    private void TransformPlates()
    {
        
        foreach (var plate in Road) 
        {
            if (isRoad[Road.IndexOf(plate)] && plate.transform.localPosition.z < Camera.main.transform.position.z) 
            {
            //    plate.transform.localPosition += new Vector3(0, 0, (Road.Count / 2) * 5);
                var pos = plate.transform.localPosition;// += new Vector3(0, 0, Road.Count * 5);
                var index = Road.IndexOf(plate);
                int newPlateNumber = UnityEngine.Random.Range(0, (isRoad.Length / 2));
                int j = 0;
                int newIndex = 0;
                for (int i = 0; i < Road.Count; i++) {
                    if (!isRoad[i] && j == newPlateNumber)
                        newIndex = i;
                    if (!isRoad[i])
                        j++;
                }
                plate.transform.localPosition += new Vector3(0, -50, -50);
                Road[newIndex].transform.localPosition = pos + new Vector3(0, 0, (Road.Count / 2) * 5);
                isRoad[index] = false;
                isRoad[newIndex] = true;
             
            }
        }
    }

    /// <summary>
    /// Move single plate.
    /// </summary>
    private void Move(Vector3 currentDirection)
    {
        foreach (var plat in Road)
        {
            if (isRoad[Road.IndexOf(plat)])
            {
                plat.transform.localPosition += currentDirection;
            }
        }
    }
}
