using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Generics;
using SocketIO;
// using Quobject.SocketIoClientDotNet.Client;

namespace PocketTank.Connection
{
    public class ConnectionService : GenericMonoSingleton<ConnectionService>
    {
        [SerializeField]
        private SocketIOComponent connectorPrefab;
        private SocketIOComponent connectorObject;
        void Start()
        {
            if(connectorObject == null)
            {
                connectorObject = GameObject.Instantiate(connectorPrefab);
                connectorObject.transform.parent = gameObject.transform;
                Debug.Log("connecting.....");
                connectorObject.On ("CONNECTION_ESTABLISHED", (SocketIOEvent ev) => {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data["PLAYER_ID"] = PlayerPrefs.GetInt("PLAYER_ID", 0).ToString();
                    data["PLAYER_NAME"] = PlayerPrefs.GetString("PLAYER_NAME", "SETHUNATH").ToString();
                    Debug.Log("sending authrequest");
                    connectorObject.Emit("USER_AUTH_REQUEST", new JSONObject(data));
                });
            }
        }

        void Update()
        {
            
        }
    }
}
