using UnityEngine;

using TMPro;
using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
    public class WaveMessageUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private WavesManager wavesManager;

        [SerializeField]
        private TextMeshProUGUI messageText;

        #endregion

        #region

        private void OnEnable()
        {
            wavesManager.onWaveStarted += EnableMessage;
        }

        private void OnDisable()
        {
            wavesManager.onWaveStarted -= EnableMessage;
        }

        private void EnableMessage(int waveNumber)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            messageText.text = string.Format("Wave {0} started", waveNumber);
            Invoke("DisableMessage", 2f);
        }

        private void DisableMessage()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        #endregion
    }
}
