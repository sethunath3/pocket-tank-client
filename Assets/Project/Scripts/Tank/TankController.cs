using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Shell;
using PocketTank.Gameplay;

namespace PocketTank.Tank
{
    public class TankController
    {
        private TankModel model;
        private TankView view;
        private ShellPool shellPool;
        private ShellView shellPrefab;
        private TankType tankType;
        public TankController(TankScriptableObject tankProps)
        {
            model = new TankModel();
            view = GameObject.Instantiate(tankProps.tankPrefab);
            view.SetController(this);
            shellPool = new ShellPool(tankProps.shellPrefab);
            tankType = tankProps.tankType;

            shellPrefab = tankProps.shellPrefab;
        }

        public void Fire()
        {
            ShellController shell = new ShellController(shellPrefab);
            shell.ProjectShell(view.GetTurretPosition(), view.GetFiringAngle());
        }

        public void SetFiringAngle(float angle)
        {
            view.SetFiringAngle(angle);
        }

        public void TakeDamage(float damage)
        {
            model.TakeDamage(damage);
            if (model.Health == 0)
            {
                view.DestroyView();
                view = null;
                if(tankType == TankType.PlayerTank)
                {
                    GameplayService.Instance.GameOver(false);
                }
                else{
                    GameplayService.Instance.GameOver(true);
                }
            }
        }

        public float GetHealth()
        {
            return model.Health;
        }
    }
}
