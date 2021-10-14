using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    public class Body : MonoBehaviour
    {
        private Quaternion startConfig;

        // Start is called before the first frame update
        void Start()
        {
            this.startConfig = transform.localRotation;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            // transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles + new Vector3(-50F, 0, 0));    
        }

        void OnCollisionEnter(Collision collision)
        {
            Debug.Log("C");
            transform.parent.GetComponent<Move>().Detected(this);
            /// parentScript.OnCollisionEnter(collision);
        }

    }
}