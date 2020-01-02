using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PocketTank.Game;
using PocketTank.Gameplay;
using System;
using PocketTank.Events;

namespace PocketTank.Screens
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField]
        private Button fireBtn;
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private Text turnInfo;

        [SerializeField]
        private Text msgText;
        [SerializeField]
        private Slider playerHealth;
        [SerializeField]
        private Slider enemyHealth;
        void Start()
        {
            if(fireBtn != null)
            {
                fireBtn.onClick.AddListener(OnFire);
            }
            EventService.Instance.GameplayEvent_EnemyGotHit+=RefreshDamageToEnemyHealthBar;
            EventService.Instance.GameplayEvent_PlayerGotHit+=RefreshDamageToPlayerHealthBar;
        }

        public void EnableTurn()
        {
            Debug.Log("Enabling turn view");
            fireBtn.enabled = true;
            slider.enabled = true;
            turnInfo.text = "Your turn";
        }

        public void DisableTurn()
        {
            Debug.Log("Disabling turn view");
            fireBtn.enabled = false;
            slider.enabled = false;
            turnInfo.text = "Enemy's turn";
        }

        private void OnFire()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["FIRING_ANGLE"] = slider.value.ToString();
            GameService.Instance.GetConnectionController().Emit("FIRED", new JSONObject(data));
            GameplayService.Instance.PlayerFired(slider.value);
        }

        public void SetMsg(string msg)
        {
            msgText.text = msg;
        }

        public void OnFiringSliderChange()
        {
            GameplayService.Instance.SetPlayerTankAngle(slider.value);
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["FIRING_ANGLE"] = slider.value.ToString();
            GameService.Instance.GetConnectionController().Emit("ANGLE_CHANGED", new JSONObject(data));
        }

        public void RefreshDamageToPlayerHealthBar()
        {
            playerHealth.value = GameplayService.Instance.GetPlayerHealth();
        }
        public void RefreshDamageToEnemyHealthBar()
        {
            enemyHealth.value = GameplayService.Instance.GetEnemyHealth();
        }
    }
}
