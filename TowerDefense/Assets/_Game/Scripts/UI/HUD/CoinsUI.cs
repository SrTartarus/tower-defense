using UnityEngine;

using TMPro;
using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
    public class CoinsUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private GameManager gameManager;

        private TextMeshProUGUI coinsText;

        #endregion

        #region BEHAVIORS

        private void OnEnable()
        {
            gameManager.onCoinsChanged += UpdateCoins;
        }

        private void Awake()
        {
            coinsText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            coinsText.text = string.Format("Coins: {0}", gameManager.Coins);
        }

        private void OnDisable()
        {
            gameManager.onCoinsChanged -= UpdateCoins;
        }

        private void UpdateCoins()
        {
            coinsText.text = string.Format("Coins: {0}", gameManager.Coins);
        }

        #endregion
    }
}
