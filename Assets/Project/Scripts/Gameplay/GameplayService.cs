using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Generics;
using PocketTank.Screens;
using PocketTank.Tank;

namespace PocketTank.Gameplay
{
    public class GameplayService : GenericMonoSingleton<GameplayService>
    {
        [SerializeField]
        private GameplayUI gameplayUIScript;
        [SerializeField]
        private GameplayPropsSO gameplayPropertiesSO;
        private GameplayController controller;

        public void StartGameplay()
        {
            controller = new GameplayController(gameplayPropertiesSO);
        }

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

        public void SetPlayerTankAngle(float angle)
        {
            controller.SetPlayerTankAngle(angle);
        }

        public void EnemyTargetChanged(float angle)
        {
            controller.SetEnemyTankAngle(angle);
        }

        
    }
}
