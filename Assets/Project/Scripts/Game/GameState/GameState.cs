using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketTank.Game
{
    public class GameState : MonoBehaviour
    {
        public virtual void OnEnterState()
        {
            this.gameObject.SetActive(true);
        }

        public virtual void OnExitState()
        {
            this.gameObject.SetActive(false);
        }
    }
}
