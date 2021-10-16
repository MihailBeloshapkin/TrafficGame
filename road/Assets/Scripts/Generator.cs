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

        [SerializeField]
        private int countOfOccupied;

        [SerializeField]
        private List<float> zPositions;

        [SerializeField]
        private int id;

        [SerializeField]
        private PoliceCreator policeCreator;

        private enum RoadObjects
        { 
            Police = 0, 
            Plat = 1
        }

        // Start is called before the first frame update
        void Start()
        {
            this.id = 0;
            this.currentObjects = new List<(GameObject, bool)>();
            this.occupiedLines = new List<int>();
            this.zPositions = new List<float>() { -2.5F, -1.5F, 0.0F, 1.5F, 2.5F };

            this.policeCreator = new PoliceCreator(this.policePrefab);
            StartCoroutine(TestCoroutine());
        }

        /// <summary>
        /// Calculates distance between two points in three-dimensional space. 
        /// </summary>
        private float distance(Vector3 first, Vector3 second)
        {
            return (float)Math.Sqrt((first.x - second.x) * (first.x - second.x) + (first.y - second.y) * (first.y - second.y) + (first.z - second.z) * (first.z - second.z));
        }

        // Generates unique id for road objects.
        private int IdGenerator() => this.id++;

        /// <summary>
        /// Objects generation. 
        /// </summary>
        IEnumerator TestCoroutine()
        {
            while (true)
            {
                float delta = UnityEngine.Random.Range(1.0F, 3.0F);
                yield return new WaitForSeconds(delta);
                if (this.currentObjects.Count < 5)
                {
                    var occupied = new List<float>();
                    foreach (var (obj, isOccupied) in this.currentObjects)
                    {
                        if (isOccupied)
                        {
                            occupied.Add(obj.transform.localPosition.x);
                        }
                    }
                    var index = UnityEngine.Random.Range(0, (zPositions.Count));
                    var sample = this.policeCreator.Create(this.IdGenerator(), new Vector3(zPositions[index], 0.2F, 40), new Vector3(0, 0, 0.07F), transform.parent.GetComponent<GameConfig>());
                    this.currentObjects.Add((sample, true));
                }
            }
        }


        // Updater.
        void FixedUpdate()
        {
            var objectsToDelete = new List<(GameObject, bool)>();
            var isOccupiedObjectsIndexes = new List<int>();
            foreach (var (obj, isOccupied) in this.currentObjects)
            {
                if (obj.transform.localPosition.z < 3.0F || obj.transform.localPosition.z > -0.5F) 
                {
                    this.countOfOccupied++;
                    var i = this.currentObjects.IndexOf((obj, isOccupied));
                    this.occupiedLines.Add(i);
                    isOccupiedObjectsIndexes.Add(i);
                }
                else {
                    this.countOfOccupied--;
                }

                if (this.distance(obj.transform.localPosition, obj.GetComponent<OnRoadObject>().StartPosition) > 100.0F)
                {
                    objectsToDelete.Add((obj, isOccupied));
                }
            }
            foreach (var index in isOccupiedObjectsIndexes) 
            {
                this.currentObjects[index] = (this.currentObjects[index].Item1, false);
            }
            foreach (var (obj, isOccupied) in objectsToDelete)
            {
                this.currentObjects.Remove((obj, isOccupied));
                Destroy(obj);
            }
        } 
    }
}