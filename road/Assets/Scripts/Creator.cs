using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Traffic;

namespace Traffic
{
    public abstract class Creator : MonoBehaviour
    {
        /// <summary>
        /// Creates onRoadObject. 
        /// </summary>
        public abstract OnRoadObject Create();
    }
}
