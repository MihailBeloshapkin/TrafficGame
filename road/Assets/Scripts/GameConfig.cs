using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    // Current speed.
    [SerializeField] private Vector3 speed;

    // Position which car starts with.
    [SerializeField]  private Vector3 carStartPosition;

    public Vector3 CarStartPosition { get => this.carStartPosition; }

    public Vector3 Speed { get => this.speed; }


    // Start is called before the first frame update
    void Start()
    {
        this.carStartPosition = new Vector3(0, 0.2F, -0.9F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
