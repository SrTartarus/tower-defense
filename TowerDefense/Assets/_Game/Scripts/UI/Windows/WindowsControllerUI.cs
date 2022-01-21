using UnityEngine;

using Zenject;

using Game.Managers;

namespace Game.UI.Windows
{
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

        private void OnEnable()
        {
            gameManager.onPlayerWon += OnPlayerWon;
            gameManager.onPlayerLose += OnPlayerLose;
        }

        private void OnDisable()
        {
            gameManager.onPlayerWon -= OnPlayerWon;
            gameManager.onPlayerLose -= OnPlayerLose;
        }

        private void OnPlayerWon()
        {
            winWindow.SetActive(true);
        }

        private void OnPlayerLose()
        {
            loseWindow.SetActive(true);
        }

        #endregion
    }
}
