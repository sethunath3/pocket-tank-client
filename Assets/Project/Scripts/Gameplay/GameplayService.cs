using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Generics;
using PocketTank.Screens;

namespace PocketTank.Gameplay
{
    public class GameplayService : GenericMonoSingleton<GameplayService>
    {
        [SerializeField]
        private GameplayUI gameplayUIScript;

        public void EnableGameplayTurn()
        {
            gameplayUIScript.EnableTurn();
        }

        public void DisableGameplayTurn()
        {
            gameplayUIScript.DisableTurn();
        }

        public void EnemyFired(float angle)
        {
            gameplayUIScript.SetMsg("Enemy Fired at an angle: " + angle);
        }
    }
}
