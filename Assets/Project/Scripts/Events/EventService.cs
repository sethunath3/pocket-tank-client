using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Generics;
using System;

namespace PocketTank.Events
{
    public class EventService : GenericSingleton<EventService>
    {
        public event Action GameplayEvent_PlayerGotHit;
        public event Action GameplayEvent_EnemyGotHit;
        void Start()
        {
            
        }

        public void PlayerGotHit()
        {
            GameplayEvent_PlayerGotHit?.Invoke();
        }
        public void EnemyGotHit()
        {
            GameplayEvent_EnemyGotHit?.Invoke();
        }
    }
}
