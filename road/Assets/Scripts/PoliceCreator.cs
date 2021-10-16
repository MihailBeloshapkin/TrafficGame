using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    public class PoliceCreator : Creator
    {
        public override OnRoadObject Create()
        {
            return new Police();
        }
    }
}
