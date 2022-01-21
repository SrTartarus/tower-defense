using UnityEngine;

using TMPro;
using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
    public class HealthUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private GameManager gameManager;

        private TextMeshProUGUI healthText;

        #endregion

        #region BEHAVIORS

        private void OnEnable()
        {
            gameManager.onHealthDecreased += UpdateHealth;
        }

        private void Awake()
        {
            healthText = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            healthText.text = string.Format("Health: {0}", gameManager.Health);
        }

        private void OnDisable()
        {
            gameManager.onHealthDecreased -= UpdateHealth;
        }

        private void UpdateHealth()
        {
            healthText.text = string.Format("Health: {0}", gameManager.Health);
        }

        #endregion
    }
}
