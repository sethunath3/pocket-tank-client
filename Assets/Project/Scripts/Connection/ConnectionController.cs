using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using PocketTank.Game;

namespace PocketTank.Connection
{
    public class ConnectionController
    {
        private SocketIOComponent connectorObject;
        public ConnectionController(SocketIOComponent connectorPrefab)
        {
            if(connectorObject == null)
            {
                connectorObject = GameObject.Instantiate(connectorPrefab);
                // connectorObject.transform.parent = gameObject.transform;
                Debug.Log("connecting.....");
                
                connectorObject.On ("CONNECTION_ESTABLISHED", GameService.Instance.ConnectionExtablished);
                connectorObject.On ("AUTH_SUCCESSFULL", GameService.Instance.UserAuthenticated);
                connectorObject.On ("MATCHMAKING_SUCCESSFULL", GameService.Instance.MatchMakingSuccessfull);
                connectorObject.On ("TURN_ACTIVE", GameService.Instance.EnableGameplayTurn);
                connectorObject.On ("TURN_INACTIVE", GameService.Instance.DisableGameplayTurn);
                connectorObject.On ("ENEMY_FIRED", GameService.Instance.EnemyFired);
            }
        }

        public void Emit(string key, JSONObject data)
        {
            connectorObject.Emit(key, data);
        }

        public void Emit(string key)
        {
            connectorObject.Emit(key);
        }

        void Update()
        {
            
        }
    }
}
