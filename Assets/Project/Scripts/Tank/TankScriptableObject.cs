﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Shell;

namespace PocketTank.Tank
{
    public enum TankType
    {
        EnemyTank = 0,
        PlayerTank
    }

    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/TankScriptableObject", order = 0)]
    
    public class TankScriptableObject : ScriptableObject
    {
        public TankView tankPrefab;
        public ShellView shellPrefab;
        public TankType tankType;
    }
}