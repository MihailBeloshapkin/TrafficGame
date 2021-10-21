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
        [SerializeField] private List<GameObject> currentObjects;

        [SerializeField] private List<GameObject> policePrefab;

        [SerializeField] private int countOfOccupied;

        [SerializeField] private List<float> zPositions;

        [SerializeField] private int id;

        [SerializeField] private PoliceCreator policeCreator;

        [SerializeField] private PlatCreator platCreator;

        [SerializeField] private List<Material> platMaterials;

        [SerializeField] private float zDistanceBetweenCars;

        [SerializeField] private List<int[][]> sampleMatrixes;

        [SerializeField] private float distance = 1000000.0F;

        [SerializeField] private List<int> leftLine;

        [SerializeField] private List<int> rightLine;

        /// <summary>
        /// Start configuration.
        /// </summary>
        public void Start()
        {
            this.id = 0;
            this.currentObjects = new List<GameObject>();
            this.zPositions = new List<float>() { -2.4F, -1.2F, 0.0F, 1.2F, 2.4F };

            this.policeCreator = new PoliceCreator(this.policePrefab);
            this.platCreator = new PlatCreator(this.platMaterials);

            this.sampleMatrixes = new List<int[][]>()
            {
                new int[][] 
                {
                    new int[] { 1, 0, 0, 0, 0 },
                    new int[] { 0, 1, 0, 0, 0 },
                    new int[] { 0, 0, 0, 0, 1 },
                    new int[] { 1, 0, 0, 1, 0 }
                },
                new int[][]
                {
                    new int[] { 0, 1, 0, 0, 1 },
                    new int[] { 0, 0, 0, 0, 0 },
                    new int[] { 0, 0, 0, 1, 1 },
                    new int[] { 1, 0, 1, 0, 0 }
                },
                new int[][]
                {
                    new int[] { 1, 0, 1, 0, 1 },
                    new int[] { 0, 1, 0, 0, 0 },
                    new int[] { 0, 0, 1, 0, 1 },
                    new int[] { 1, 0, 0, 0, 0 }
                },
                new int[][]
                {
                    new int[] { 1, 0, 0, 0, 0 },
                    new int[] { 0, 0, 1, 0, 0 },
                    new int[] { 1, 0, 0, 1, 0 },
                    new int[] { 0, 0, 1, 0, 1 }
                },
                new int[][]
                {
                    new int[] { 1, 0, 0, 0, 1 },
                    new int[] { 0, 0, 0, 0, 0 },
                    new int[] { 1, 0, 1, 0, 0 },
                    new int[] { 0, 0, 0, 0, 1 }
                },
                new int[][]
                {
                    new int[] { 0, 1, 0, 1, 0 },
                    new int[] { 1, 0, 0, 0, 0 },
                    new int[] { 0, 0, 1, 1, 0 },
                    new int[] { 0, 0, 1, 0, 0 }
                }
            };

//            int sampleIndex = UnityEngine.Random.Range(0, this.sampleMatrixes.Count);
//            this.GenerateSample(sampleIndex);
        }

        /// <summary>
        /// Calculates distance between two points in three-dimensional space. 
        /// </summary>
        private float Distance(Vector3 first, Vector3 second)
        {
            return (float)Math.Sqrt((first.x - second.x) * (first.x - second.x) + (first.y - second.y) * (first.y - second.y) + (first.z - second.z) * (first.z - second.z));
        }

        // Generates unique id for road objects.
        private int IdGenerator() => this.id++;

        IEnumerator NewCoroutine()
        {
            yield return new WaitForSeconds(5.0F);
        }

      
        /// <summary>
        /// Generates sample from sample matrix.
        /// </summary>
        private void GenerateSample(int index) 
        {
            Vector3 startZPosition = new Vector3(zPositions[0], 0.2F, 70);
            int[][] sampleMatrix = this.sampleMatrixes[index];

            foreach (var line in sampleMatrix)
            {
                foreach (var position in line)
                {
                    if (position == 1)
                    {
                        float delta = UnityEngine.Random.Range(-1F, 1F);
                        int newId = this.IdGenerator();
                        var speed = new Vector3(0, 0, 0.07F);
                        var state = transform.parent.GetComponent<GameConfig>();
                        var sample = this.policeCreator.Create(newId, startZPosition + new Vector3(0, 0, delta), speed, state);
                        this.currentObjects.Add(sample);
                    }
                    startZPosition += new Vector3(1.2F, 0, 0);
                }
                startZPosition.x = zPositions[0];
                startZPosition -= new Vector3(0, 0, this.zDistanceBetweenCars);
            }
        }

        private IEnumerable LineChanger()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.0F);
            }

        }

        /// <summary>
        /// Manages generation of objects.
        /// </summary>
        void FixedUpdate()
        {
            var objectsToDelete = new List<GameObject>();
            var isOccupiedObjectsIndexes = new List<int>();

            distance = 1000000.0F;

            foreach (var obj in this.currentObjects)
            {
                float objCoordinateZ = obj.transform.localPosition.z;
                if (Math.Abs(obj.transform.localPosition.z - 70.0F) < distance)
                {
                    distance = Math.Abs(obj.transform.localPosition.z - 70.0F);
                }

                if (this.Distance(obj.transform.localPosition, obj.GetComponent<OnRoadObject>().StartPosition) > 100.0F)
                {
                    objectsToDelete.Add(obj);
                }
            }

            foreach (var obj in objectsToDelete)
            {
                this.currentObjects.Remove(obj);
                Destroy(obj);
            }

            if (distance > 25.0F)
            {
                int sampleIndex = UnityEngine.Random.Range(0, this.sampleMatrixes.Count);
                this.GenerateSample(sampleIndex);
            }
        }

        /// <summary>
        /// If game finished.
        /// </summary>
        public void Restart()
        {
            foreach (var obj in this.currentObjects)
            {
                Destroy(obj);
            }
            currentObjects = new List<GameObject>();
        }
    }
}