using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Traffic;

namespace Traffic
{
    public class PlatCreator : Creator
    {
        // Create sample.
        public override OnRoadObject Create()
        {
            return new Plat();
        }
    }
}
