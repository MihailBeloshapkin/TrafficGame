using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    /// <summary>
    /// Generates objects on the road.
    /// </summary>
    public class Generator : MonoBehaviour
    {
        [SerializeField]
        public GameObject cube;

        [SerializeField]
        private List<OnRoadObject> onRoadObjectsPrefabs;

        [SerializeField]
        private List<(GameObject, bool)> currentObjects;

        [SerializeField]
        private GameObject platPrefab;

        [SerializeField]
        private GameObject policePrefab;

        [SerializeField]
        private List<int> occupiedLines;

        private List<float> zPositions;

        private enum RoadObjects
        { 
            Police = 0, 
            Plat = 1
        }

        // Start is called before the first frame update
        void Start()
        {
            this.currentObjects = new List<(GameObject, bool)>();
            this.occupiedLines = new List<int>();
            this.zPositions = new List<float>() { -3.0F, -2.0F, -1.0F, 0.0F, 1.0F. 2.0F, 3.0F };
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
                var occupied = new List<float>();
                foreach (var (obj, isOccupied) in this.currentObjects)
                {
                    if (isOccupied)
                    {
                        occupied.Add(obj.transform.localPosition.x);
                    }
                }
                var pl = Instantiate(policePrefab);
                pl.GetComponent<OnRoadObject>().Speed = transform.parent.GetComponent<GameConfig>().Speed;
                var index = UnityEngine.Random.Range(0, (zPositions.Count - 1));
                pl.GetComponent<OnRoadObject>().StartPosition = new Vector3(zPositions[index], 0.3F, 20);
                currentObjects.Add((pl, true));
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
            var objectsToDelete = new List<(GameObject, bool)>();
            var isOccupiedObjectsIndexes = new List<int>();
            foreach (var (obj, isOccupied) in this.currentObjects)
            {
                if (obj.transform.localPosition.z > 10F || obj.transform.localPosition.z < 0.0F) 
                {
                    var i = this.currentObjects.IndexOf((obj, isOccupied));
                    isOccupiedObjectsIndexes.Add(i);
                }
                if (Math.Abs(obj.transform.localPosition.z - obj.GetComponent<OnRoadObject>().StartPosition.z) > 100.0F)
                {
                    objectsToDelete.Add((obj, isOccupied));
                }
            }
            foreach (var index in isOccupiedObjectsIndexes) {
                this.currentObjects[index] = (this.currentObjects[index].Item1, false);
            }
            foreach (var (obj, isOccupied) in objectsToDelete)
            {
                this.currentObjects.Remove((obj, isOccupied));
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