using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketTank.Tank
{
    public class TankModel : MonoBehaviour
    {
        private float health;
        public float Health{get{return health;} set{health =  value;}}

        public TankModel()
        {
            health = 100;
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            if(health < 0)
            {
                health = 0;
            }
        }
    }
}
