using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Traffic;

namespace Traffic
{
    /// <summary>
    /// Manages objects creation.
    /// </summary>
    public abstract class Creator : ScriptableObject
    {
        /// <summary>
        /// Creates onRoadObject. 
        /// </summary>
        public abstract GameObject Create(int id, Vector3 startPosition, Vector3 speed, GameConfig state);
    }
}
