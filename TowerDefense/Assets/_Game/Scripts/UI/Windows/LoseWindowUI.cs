using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.UI.Windows
{
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

        private void Continue()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}

