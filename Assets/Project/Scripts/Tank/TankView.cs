using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketTank.Tank
{
    public class TankView : MonoBehaviour
    {
        [SerializeField]
        private TurretView turretView;
        public void SetPosition(Vector3 position)
        {

        }

        public void SetDirection()
        {
            
        }

        public void SetFiringAngle(float angle)
        {
            if(turretView != null)
            {
                turretView.SetFiringAngle(angle);
            }
        }
    }
}
