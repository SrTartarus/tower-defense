using UnityEngine;

using TMPro;
using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
    // This Class is attached to a GameObject UI
    public class HealthUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private GameManager gameManager;

        private TextMeshProUGUI healthText;

        #endregion

        #region BEHAVIORS

        // Subscribing to onHealthDecreased to update UI
        private void OnEnable()
        {
            gameManager.onHealthDecreased += UpdateHealth;
        }

        private void Awake()
        {
            healthText = GetComponent<TextMeshProUGUI>();
        }

        // Setting default value
        private void Start()
        {
            healthText.text = string.Format("Health: {0}", gameManager.Health);
        }

        // Unsubscribing to onHealthDecreased to update UI
        private void OnDisable()
        {
            gameManager.onHealthDecreased -= UpdateHealth;
        }

        // Updating UI after receiving new coins event
        private void UpdateHealth()
        {
            healthText.text = string.Format("Health: {0}", gameManager.Health);
        }

        #endregion
    }
}
