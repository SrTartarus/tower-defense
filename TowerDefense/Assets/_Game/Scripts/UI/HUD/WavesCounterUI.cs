using UnityEngine;

using TMPro;
using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
    // This Class is Attached to GameObjectUI
    public class WavesCounterUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private WavesManager wavesManager;

        private TextMeshProUGUI wavesText;

        #endregion

        #region BEHAVIORS

        // Subscring to onWaveStarted
        private void OnEnable()
        {
            wavesManager.onWaveStarted += UpdateWaves;
        }

        private void Awake()
        {
            wavesText = GetComponent<TextMeshProUGUI>();
        }

        // Setting wave status as default
        private void Start()
        {
            wavesText.text = string.Format("{0}/{1} Waves", 0, wavesManager.MaximumWaves);
        }

        // Unsubscring to onWaveStarted
        private void OnDisable()
        {
            wavesManager.onWaveStarted -= UpdateWaves;
        }

        // Updading UI to get waves status
        private void UpdateWaves(int waveNumber)
        {
            wavesText.text = string.Format("{0}/{1} Waves", waveNumber, wavesManager.MaximumWaves);
        }

        #endregion
    }
}
