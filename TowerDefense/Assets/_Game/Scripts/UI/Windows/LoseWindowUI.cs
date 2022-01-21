using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.UI.Windows
{
    // This Class enables Lose window
    public class LoseWindowUI : MonoBehaviour
    {
        #region FIELDS

        [SerializeField]
        private Button continueButton;

        [SerializeField]
        private Button retryButton;

        #endregion

        #region BEHAVIORS

        private void Start()
        {
            continueButton.onClick.AddListener(Continue);
            retryButton.onClick.AddListener(Retry);
        }

        // Pressing continue button will go back to Map
        private void Continue()
        {
            SceneManager.LoadScene("Map");
        }

        // Pressing retry button will reload the scene to start again
        private void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}

