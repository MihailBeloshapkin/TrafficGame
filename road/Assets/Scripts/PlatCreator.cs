using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Traffic;

namespace Traffic
{
    public class PlatCreator : Creator
    {
        [SerializeField]
        private GameObject obj;

        // Create sample.
        public override void Create()
        {
            Instantiate(this.obj);
        }
    }
}
