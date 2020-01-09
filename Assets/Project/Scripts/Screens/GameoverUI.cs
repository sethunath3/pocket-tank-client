using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PocketTank.Game;

namespace PocketTank.Screens
{
    public class GameoverUI : MonoBehaviour
    {
        [SerializeField]
        private Text resultMsg;
        [SerializeField]
        private Button okBtn;

        private void Start()
        {
            if(okBtn != null)
            {
                okBtn.onClick.AddListener(OnContinue);
            }
        }

        public void EnableUI(bool enable)
        {
            gameObject.SetActive(enable);
        }

        public void SetWinMessage(bool won)
        {
            if (won)
            {
                resultMsg.text = "You Won";
            }
            else
            {
                resultMsg.text = "You Lost";
            }
        }

        private void OnContinue()
        {
            GameService.Instance.EnterLobbyScreen();
        }
    }
}
