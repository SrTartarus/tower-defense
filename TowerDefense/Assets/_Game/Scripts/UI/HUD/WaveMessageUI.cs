using UnityEngine;

using TMPro;
using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
    // This Class is Attached to a GameObject UI
    public class WaveMessageUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private WavesManager wavesManager;

        [SerializeField]
        private TextMeshProUGUI messageText;

        #endregion

        #region

        // Subscribing to onWaveStarted
        private void OnEnable()
        {
            wavesManager.onWaveStarted += EnableMessage;
        }

        // Unsubscribing to onWaveStarted
        private void OnDisable()
        {
            wavesManager.onWaveStarted -= EnableMessage;
        }

        // After countdown from Waves Manager comes to 0. this function enables message
        private void EnableMessage(int waveNumber)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            messageText.text = string.Format("Wave {0} started", waveNumber);
            Invoke("DisableMessage", 2f);
        }

        // After few seconds this function disables message
        private void DisableMessage()
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        #endregion
    }
}
