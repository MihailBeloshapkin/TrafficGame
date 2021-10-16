using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Traffic
{
    /// <summary>
    /// Conveer.
    /// </summary>
    public class Conv : MonoBehaviour
    {
        /// Current plates
        [SerializeField]
        private List<GameObject> Road;

        [SerializeField]
        private List<Material> materials;

        /// <summary>
        /// Bool array. 
        /// </summary>
        [SerializeField]
        private bool[] isRoad;

        [SerializeField]
        private int size = 0;

        /// <summary>
        /// Current size of the road.
        /// </summary>
        public int Size
        {
            get => this.size;
            set
            {
                foreach (var pl in this.Road)
                {
                    Destroy(pl);
                }
                this.size = value;
                this.Start();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 40; i++)
            {
                GameObject plat = GameObject.CreatePrimitive(PrimitiveType.Cube);
                plat.transform.localPosition = new Vector3(0, 0, 0);
                plat.transform.localScale = new Vector3(6, 0.5F, 5);
                plat.AddComponent<MeshRenderer>();
                int materialIndex = UnityEngine.Random.Range(0, this.materials.Count);
                plat.GetComponent<MeshRenderer>().material = this.materials[materialIndex];
                this.Road.Add(plat);
            }

            isRoad = new bool[Road.Count];

            int iter = 0;
            int roadIndex = 0;

            foreach (var plat in Road)
            {
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
            var instantSpeed = transform.parent.GetComponent<GameConfig>().InstantSpeed;
            if (Input.GetKey(KeyCode.W))
            {
                Move(instantSpeed * 1.1F);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Move(instantSpeed * 0.9F);
            }
            else
            {
                Move(instantSpeed);
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
                if (isRoad[Road.IndexOf(plate)] && plate.transform.localPosition.z < Camera.main.transform.position.z - 5)
                {
                    //    plate.transform.localPosition += new Vector3(0, 0, (Road.Count / 2) * 5);
                    var pos = plate.transform.localPosition;// += new Vector3(0, 0, Road.Count * 5);
                    var index = Road.IndexOf(plate);
                    int newPlateNumber = UnityEngine.Random.Range(0, (isRoad.Length / 2));
                    int j = 0;
                    int newIndex = 0;
                    for (int i = 0; i < Road.Count; i++)
                    {
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
}