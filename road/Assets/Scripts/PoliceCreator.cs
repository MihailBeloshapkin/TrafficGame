using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    /// <summary>
    /// Creates police instance.
    /// </summary>
    public class PoliceCreator : Creator
    {
        [SerializeField] private List<GameObject> policePrefab;

        public PoliceCreator(List<GameObject> policePrefab)
        {
            this.policePrefab = policePrefab;
        }

        // Create sample.
        public override GameObject Create(int id, Vector3 startPosition, Vector3 speed, GameConfig state)
        {
            int index = UnityEngine.Random.Range(0, this.policePrefab.Count);
            var pl = Instantiate(this.policePrefab[index]);
            pl.GetComponent<OnRoadObject>().Speed = speed;
            pl.GetComponent<OnRoadObject>().StartPosition = startPosition;
            pl.GetComponent<OnRoadObject>().State = state;
            pl.GetComponent<OnRoadObject>().Id = id;
            return pl;
        }
    }
}
