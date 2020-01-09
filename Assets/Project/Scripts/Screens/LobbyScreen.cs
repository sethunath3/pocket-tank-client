using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PocketTank.Game;

namespace PocketTank.Screens
{
    public class LobbyScreen : MonoBehaviour
    {
        [SerializeField]
        private Button playBtn;
        void Start()
        {
            if(playBtn != null)
            {
                playBtn.onClick.AddListener(OnPlayBtnClick);
            }
        }

        private void OnPlayBtnClick()
        {
            GameService.Instance.InitiateMatchMaking();
        } 
    }
}
