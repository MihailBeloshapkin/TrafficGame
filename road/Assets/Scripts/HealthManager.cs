using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> healthList;

    [SerializeField] private int index;

    void Start()
    {
        this.index = healthList.Count - 1;
    }

    public void Damage()
    {
        healthList[index].SetActive(false);
        if (index > 0)
            index--;
    }
}
