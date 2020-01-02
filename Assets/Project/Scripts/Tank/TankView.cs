using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Interfaces;

namespace PocketTank.Tank
{
    public class TankView : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private TurretView turretView;
        private TankController controller;
        public void SetPosition(Vector3 position)
        {

        }

        public void SetDirection()
        {
            
        }

        public void SetController(TankController _controller)
        {
            controller = _controller;
        }

        public void SetFiringAngle(float angle)
        {
            if(turretView != null)
            {
                turretView.SetFiringAngle(angle);
            }
        }

        public Quaternion GetFiringAngle()
        {
            return turretView.GetFiringAngle();
        }

        public Vector3 GetTurretPosition()
        {
            return turretView.gameObject.transform.position;
        }

        public void TakeDamage(float damage)
        {
            controller.TakeDamage(damage);
        }

        public void DestroyView()
        {
            Destroy(turretView.gameObject);
            Destroy(gameObject);
        }

        public Vector2 GetPosition()
        {
            return gameObject.transform.position;
        }
    }
}
