using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    public class Generator : MonoBehaviour
    {
        [SerializeField]
        private Move carInfo;

        [SerializeField]
        public GameObject cube;

        [SerializeField]
        private List<OnRoadObject> onRoadObjectsSamples;

        [SerializeField]
        private List<GameObject> currentObjects;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void Generation()
        {
            var a = Instantiate(this.onRoadObjectsSamples[0]);
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
}