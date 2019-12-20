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

        public void InitializeGameplay()
        {
            playerTank = new TankController(gameplayPropertiesSO.playerTankPrefab);
            enemyTank = new TankController(gameplayPropertiesSO.enemyTankPrefab);
        }

        public void SetPlayerTankAngle(float angle)
        {
            playerTank.SetFiringAngle(angle);
        }

        public void SetEnemyTankAngle(float angle)
        {
            enemyTank.SetFiringAngle(180-angle);
        }
    }
}
