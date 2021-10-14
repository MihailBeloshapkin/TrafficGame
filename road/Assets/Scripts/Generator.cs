using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    public class Generator : MonoBehaviour
    {
        [SerializeField]
        public GameObject cube;

        [SerializeField]
        private List<OnRoadObject> onRoadObjectsPrefabs;

        [SerializeField]
        private List<GameObject> currentObjects;

        [SerializeField]
        private GameObject platPrefab;

        [SerializeField]
        private GameObject policePrefab;

        private System.Object locker = new System.Object();

        [SerializeField]
        private List<int> li;

        // Start is called before the first frame update
        void Start()
        {
            this.currentObjects = new List<GameObject>();
            StartCoroutine(TestCoroutine());
        /*    this.currentObjects = new List<GameObject>();
            var pl = Instantiate(platPrefab);
            pl.GetComponent<Plat>().Speed = transform.parent.GetComponent<GameConfig>().Speed;
            pl.GetComponent<Plat>().StartPosition = new Vector3(0, 0.3F, 20);
            currentObjects.Add(pl); */
        }

        private void Generation()
        {
        }

        IEnumerator TestCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(2.0F);
                var pl = Instantiate(policePrefab);
                pl.GetComponent<OnRoadObject>().Speed = transform.parent.GetComponent<GameConfig>().Speed;
                pl.GetComponent<OnRoadObject>().StartPosition = new Vector3(UnityEngine.Random.Range(-3, 3), 0.3F, 20);
                currentObjects.Add(pl);
                Debug.Log(Time.deltaTime);
            }
            /*
            while (true)
            {
                yield return new WaitForSeconds(2.0F);
                var pl = Instantiate(platPrefab);
                pl.GetComponent<Plat>().Speed = transform.parent.GetComponent<GameConfig>().Speed;
                pl.GetComponent<Plat>().StartPosition = new Vector3(UnityEngine.Random.Range(-3, 3), 0.3F, 20);
                currentObjects.Add(pl);
                Debug.Log(Time.deltaTime);
            } */
        }


        // Updater.
        void FixedUpdate()
        {
            var objectsToDelete = new List<GameObject>();
            foreach (var obj in this.currentObjects)
            {
                if (Math.Abs(obj.transform.localPosition.z - obj.GetComponent<OnRoadObject>().StartPosition.z) > 100.0F)
                {
                    objectsToDelete.Add(obj);
                }
            }
            foreach (var obj in objectsToDelete)
            {
                this.currentObjects.Remove(obj);
                Destroy(obj);
            }
            
            // var newObj = Instantiate
            
                /*
            if (cube.transform.localPosition.z < carInfo.StartPosition.z - 7)
            {
                cube.transform.localPosition = carInfo.StartPosition + new Vector3(UnityEngine.Random.Range(-3, 3), 0, 10);
            }
            cube.transform.localPosition += new Vector3(0, 0, -0.1F); */ 
        } 
    }
}