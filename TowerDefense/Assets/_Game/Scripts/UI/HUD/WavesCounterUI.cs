using UnityEngine;

using TMPro;
using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
    public class WavesCounterUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private WavesManager wavesManager;

        private TextMeshProUGUI wavesText;

        #endregion

        #region BEHAVIORS

        private void OnEnable()
        {
            wavesManager.onWaveStarted += UpdateWaves;
        }

        private void Awake()
        {
            wavesText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            wavesText.text = string.Format("{0}/{1} Waves", 0, wavesManager.MaximumWaves);
        }

        private void OnDisable()
        {
            wavesManager.onWaveStarted -= UpdateWaves;
        }

        private void UpdateWaves(int waveNumber)
        {
            wavesText.text = string.Format("{0}/{1} Waves", waveNumber, wavesManager.MaximumWaves);
        }

        #endregion
    }
}
