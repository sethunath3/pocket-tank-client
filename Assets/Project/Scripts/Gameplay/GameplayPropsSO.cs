using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Tank;

namespace PocketTank.Gameplay
{
    [CreateAssetMenu(fileName = "GameplayPropsSO", menuName="ScriptableObjects/GameplayProps", order = 0)]
    public class GameplayPropsSO : ScriptableObject
    {
        public TankView playerTankPrefab;
        public TankView enemyTankPrefab;
    }
}
