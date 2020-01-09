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
        public GameObject explosionPrefab;
        [SerializeField]
        private GameplayUI gameplayUIScript;
        [SerializeField]
        private GameoverUI gameOverUIScript;
        [SerializeField]
        private GameplayPropsSO gameplayPropertiesSO;
        private GameplayController controller;

        public void StartGameplay()
        {
            controller = new GameplayController(gameplayPropertiesSO);
            gameOverUIScript.EnableUI(false);
        }

        public float GetPlayerHealth()
        {
            return controller.GetPlayerHealth();
        }
        public float GetEnemyHealth()
        {
            return controller.GetEnemyHealth();
        }

        public void EnableGameplayTurn()
        {
            gameplayUIScript.EnableTurn(true);
        }

        public void DisableGameplayTurn()
        {
            gameplayUIScript.EnableTurn(false);
        }

        public void EnemyFired(float angle)
        {
            controller.EnemyFired(angle);
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

        public void PlayerFired(float angle)
        {
            controller.PlayerFired(angle);
        }

        public void GameOver(bool won)
        {
            gameOverUIScript.EnableUI(true);
            gameOverUIScript.SetWinMessage(won);
        }
    }
}
