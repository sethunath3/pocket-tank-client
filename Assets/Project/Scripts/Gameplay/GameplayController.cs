using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Tank;

namespace PocketTank.Gameplay
{
    public class GameplayController
    {
        private GameplayPropsSO gameplayPropertiesSO;
        private TankController playerTank;
        private TankController enemyTank;
        public GameplayController(GameplayPropsSO _gameplayPropertiesSO)
        {
            gameplayPropertiesSO = _gameplayPropertiesSO;
            InitializeGameplay();
        }

        public float GetPlayerHealth()
        {
            return playerTank.GetHealth();
        }
        public float GetEnemyHealth()
        {
            return enemyTank.GetHealth();
        }

        public void InitializeGameplay()
        {
            playerTank = new TankController(gameplayPropertiesSO.playerTankProps);
            enemyTank = new TankController(gameplayPropertiesSO.enemyTankProps);
        }

        public void SetPlayerTankAngle(float angle)
        {
            playerTank.SetFiringAngle(angle);
        }

        public void SetEnemyTankAngle(float angle)
        {
            enemyTank.SetFiringAngle(180-angle);
        }

        public void PlayerFired(float angle)
        {
            playerTank.SetFiringAngle(angle);
            playerTank.Fire();
        }

        public void EnemyFired(float angle)
        {
            enemyTank.SetFiringAngle(180-angle);
            enemyTank.Fire();
        }
    }
}
