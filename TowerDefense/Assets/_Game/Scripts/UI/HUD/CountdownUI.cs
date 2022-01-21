using UnityEngine;

using TMPro;
using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
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

        private void Update()
        {
            countdownText.text = wavesManager.WaveCountDown.ToString();
        }

        #endregion
    }
}
