using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    /// <summary>
    /// Health manager.
    /// </summary>
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> healthList;

        [SerializeField] private int index;

        void Start()
        {
            this.index = healthList.Count - 1;
        }

        /// <summary>
        /// Damage.
        /// </summary>
        public void Damage(int damage)
        {
            for(int i = 0; i < System.Math.Abs(damage); i++)
            {
                if (damage > 0)
                {
                    healthList[index].SetActive(false);
                    if (index > 0)
                        index--;
                }
                if (damage < 0)
                {
                    healthList[index].SetActive(true);
                    if (index < this.healthList.Count - 1)
                        index++;
                }
            }
        }
    }
}