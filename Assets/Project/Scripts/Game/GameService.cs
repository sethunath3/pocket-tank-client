using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Connection;
using SocketIO;
using PocketTank.Generics;

namespace PocketTank.Game
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [SerializeField]
        private SocketIOComponent connectorPrefab;
        [SerializeField]
        private AuthState authState;
        [SerializeField]
        private GameplayState gamePlayState;
        [SerializeField]
        private LobbyState lobbyState;
        [SerializeField]
        private MatchMakingState matchMakingState;
        private ConnectionController connectionController;
        private GameState currentGameState;
        void Start()
        {
            connectionController = new ConnectionController(connectorPrefab);
        }

        void Update()
        {
            
        }

        public void ConnectionExtablished(SocketIOEvent ev)
        {
            ChangeGameState(authState);
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["PLAYER_ID"] = PlayerPrefs.GetInt("PLAYER_ID", 0).ToString();
            data["PLAYER_NAME"] = PlayerPrefs.GetString("PLAYER_NAME", "SETHUNATH").ToString();
            Debug.Log("sending authrequest");
            connectionController.Emit("USER_AUTH_REQUEST", new JSONObject(data));
        }

        public void UserAuthenticated(SocketIOEvent ev)
        {
            ChangeGameState(lobbyState);
        }

        public void InitiateMatchMaking()
        {
            ChangeGameState(matchMakingState);
            connectionController.Emit("INITIATE_MATCH_MAKING");
            ChangeGameState(matchMakingState);
        }

        public void MatchMakingSuccessfull(SocketIOEvent ev)
        {
            ChangeGameState(gamePlayState);
        }

        private void ChangeGameState(GameState newState)
        {
            if (currentGameState != null)
            {
                currentGameState.OnExitState();
            }
            currentGameState = newState;
            currentGameState.OnEnterState();
        }
                    
    }
}
