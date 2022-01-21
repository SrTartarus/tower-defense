using UnityEngine;

using TMPro;
using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
    // This class is attached to a GameObject UI
    public class CoinsUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private GameManager gameManager;

        private TextMeshProUGUI coinsText;

        #endregion

        #region BEHAVIORS

        // Subscribing to onCoinsChanged to update UI
        private void OnEnable()
        {
            gameManager.onCoinsChanged += UpdateCoins;
        }

        private void Awake()
        {
            coinsText = GetComponent<TextMeshProUGUI>();
        }

        // Setting default value
        private void Start()
        {
            coinsText.text = string.Format("Coins: {0}", gameManager.Coins);
        }

        // Unsubscribing to onCoinsChanged to update UI
        private void OnDisable()
        {
            gameManager.onCoinsChanged -= UpdateCoins;
        }

        // Updating UI after receiving new coins event
        private void UpdateCoins()
        {
            coinsText.text = string.Format("Coins: {0}", gameManager.Coins);
        }

        #endregion
    }
}
