using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Connection;
using SocketIO;
using PocketTank.Generics;
using PocketTank.Gameplay;

namespace PocketTank.Game
{
    public enum GameLayers
    {
        PlayerTank = 8,
        Ground = 11,
        EnemyTank = 12
    }
    
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

        public ConnectionController GetConnectionController()
        {
            return connectionController;
        }

        void Update()
        {
            
        }

        public void ConnectionExtablished(SocketIOEvent ev)
        {
            Debug.Log("first scene");
            ChangeGameState(authState);
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["PLAYER_ID"] = PlayerPrefs.GetInt("PLAYER_ID", 0).ToString();
            data["PLAYER_NAME"] = PlayerPrefs.GetString("PLAYER_NAME", "SETHUNATH").ToString();
            Debug.Log("sending authrequest");
            connectionController.Emit("USER_AUTH_REQUEST", new JSONObject(data));
        }

        public void UserAuthenticated(SocketIOEvent ev)
        {
            EnterLobbyScreen();
        }

        public void EnterLobbyScreen()
        {
            ChangeGameState(lobbyState);
        }

        public void InitiateMatchMaking()
        {
            connectionController.Emit("INITIATE_MATCH_MAKING");
            ChangeGameState(matchMakingState);
        }

        public void MatchMakingSuccessfull(SocketIOEvent ev)
        {
            ChangeGameState(gamePlayState);
            GameplayService.Instance.StartGameplay();
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

        public void EnableGameplayTurn(SocketIOEvent ev)
        {
            if (currentGameState == gamePlayState)
            {
                Debug.Log("enabling turn auto");
                GameplayService.Instance.EnableGameplayTurn();
            }
        }

        public void DisableGameplayTurn(SocketIOEvent ev)
        {
            if (currentGameState == gamePlayState)
            {
                GameplayService.Instance.DisableGameplayTurn();
            }
        }

        public void EnemyFired(SocketIOEvent ev)
        {
            Debug.Log("enemy firing");
            if (currentGameState == gamePlayState)
            {
                Debug.Log("enemy firing");
                float firingAngle = float.Parse(ev.data.ToDictionary()["FIRING_ANGLE"]);
                GameplayService.Instance.EnemyFired(firingAngle);
            }
        }

        public void EnemyChangedAngle(SocketIOEvent ev)
        {
            if (currentGameState == gamePlayState)
            {
                float firingAngle = float.Parse(ev.data.ToDictionary()["FIRING_ANGLE"]);
                GameplayService.Instance.EnemyTargetChanged(firingAngle);
            }
        }
                    
    }
}
