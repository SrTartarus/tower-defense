using UnityEngine;

using TMPro;
using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
    // This Class is attached to a GameObject UI
    public class CountdownUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private WavesManager wavesManager;

        private TextMeshProUGUI countdownText;

        #endregion

        #region BEHAVIORS

        private void Awake()
        {
            countdownText = GetComponent<TextMeshProUGUI>();
        }

        // Updating countdown from waves manager
        private void Update()
        {
            countdownText.text = wavesManager.WaveCountDown.ToString();
        }

        #endregion
    }
}
