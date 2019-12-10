using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PocketTank.Game;

namespace PocketTank.Screens
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField]
        private Button fireBtn;
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private Text msgText;
        void Start()
        {
            if(fireBtn != null)
            {
                fireBtn.onClick.AddListener(OnFire);
            }
        }

        void Update()
        {
            
        }

        public void EnableTurn()
        {
            Debug.Log("Enabling turn view");
            fireBtn.enabled = true;
            slider.enabled = true;
            // msgText.text = "Your turn";
        }

        public void DisableTurn()
        {
            Debug.Log("Disabling turn view");
            fireBtn.enabled = false;
            slider.enabled = false;
            msgText.text = "Enemy's turn";
        }

        private void OnFire()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["FIRING_ANGLE"] = slider.value.ToString();
            GameService.Instance.GetConnectionController().Emit("FIRED", new JSONObject(data));
        }

        public void SetMsg(string msg)
        {
            msgText.text = msg;
        }
    }
}
