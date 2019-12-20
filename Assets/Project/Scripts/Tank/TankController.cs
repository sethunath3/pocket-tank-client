using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketTank.Tank
{
    public class TankController
    {
        TankModel model;
        TankView view;
        public TankController(TankView tankPrefab)
        {
            model = new TankModel();
            view = GameObject.Instantiate(tankPrefab);
        }

        public void SetFiringAngle(float angle)
        {
            view.SetFiringAngle(angle);
        }
    }
}
