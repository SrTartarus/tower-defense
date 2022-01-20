using UnityEngine;
using UnityEngine.UI;

using Zenject;

using Game.Managers;

namespace Game.UI
{
    public class CountdownUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private WavesManager wavesManager;

        private Text countdownText;

        #endregion

        #region BEHAVIORS

        private void Awake()
        {
            countdownText = GetComponent<Text>();
        }

        private void Update()
        {
            countdownText.text = wavesManager.WaveCountDown.ToString();
        }

        #endregion
    }
}
