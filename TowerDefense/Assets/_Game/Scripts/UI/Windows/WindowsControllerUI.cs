using UnityEngine;

using Zenject;

using Game.Managers;

namespace Game.UI.Windows
{
    // This class enables win and lose windows depending player status
    public class WindowsControllerUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private GameManager gameManager;

        [SerializeField]
        private GameObject winWindow;

        [SerializeField]
        private GameObject loseWindow;

        #endregion

        #region BEHAVIORS

        // Subscring to player status events
        private void OnEnable()
        {
            gameManager.onPlayerWon += OnPlayerWon;
            gameManager.onPlayerLose += OnPlayerLose;
        }

        // Unsubscring to player status events
        private void OnDisable()
        {
            gameManager.onPlayerWon -= OnPlayerWon;
            gameManager.onPlayerLose -= OnPlayerLose;
        }

        // Enabling win window
        private void OnPlayerWon()
        {
            winWindow.SetActive(true);
        }

        // Enabling lose window
        private void OnPlayerLose()
        {
            loseWindow.SetActive(true);
        }

        #endregion
    }
}
