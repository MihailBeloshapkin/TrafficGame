using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Traffic;

namespace Traffic
{
    /// <summary>
    /// Creates plate instance.
    /// </summary>
    public class PlatCreator : Creator
    {
        [SerializeField] private List<Material> materials;

        public PlatCreator(List<Material> materials)
        {
            this.materials = materials;
        }

        // Create sample.
        public override GameObject Create(int id, Vector3 startPosition, Vector3 speed, GameConfig state)
        {
            GameObject plat = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plat.AddComponent<Plat>();
            plat.GetComponent<OnRoadObject>().StartPosition = startPosition;
            plat.GetComponent<OnRoadObject>().Speed = new Vector3(0, 0, 0);
            plat.GetComponent<OnRoadObject>().State = state;
            plat.transform.localScale = new Vector3(1, 1, 1);

            // And set random material.
            if (this.materials.Count > 0)
            {
                int materialIndex = UnityEngine.Random.Range(0, this.materials.Count);
                plat.GetComponent<MeshRenderer>().material = this.materials[materialIndex];
            }
            return plat;
        }
    }
}
