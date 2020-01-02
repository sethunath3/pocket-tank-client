using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketTank.Tank
{
    public class TurretView : MonoBehaviour
    {
        public void SetFiringAngle(float angle)
        {
            Debug.Log("angle: " + angle);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        public Quaternion GetFiringAngle()
        {
            return gameObject.transform.rotation;
        }
    }
}
