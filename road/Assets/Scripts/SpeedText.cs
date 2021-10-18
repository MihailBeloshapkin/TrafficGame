using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Traffic
{
    public class SpeedText : MonoBehaviour
    {
        // Update is called once per frame
        void FixedUpdate()
        {
            var instantSpeed = transform.parent.parent.GetComponent<GameConfig>().InstantSpeed.z;
            var speedValue = -(int)(instantSpeed * 300);
            GetComponent<UnityEngine.UI.Text>().text = speedValue.ToString() + "mph";
        }
    }
}