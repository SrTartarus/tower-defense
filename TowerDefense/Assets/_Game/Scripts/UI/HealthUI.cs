using UnityEngine;
using UnityEngine.UI;

using Zenject;

using Game.Managers;

namespace Game.UI
{
    public class HealthUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private GameManager gameManager;

        private Text healthText;

        #endregion

        #region BEHAVIORS

        private void OnEnable()
        {
            gameManager.onHealthDecreased += UpdateHealth;
        }

        private void Awake()
        {
            healthText = GetComponent<Text>();
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
