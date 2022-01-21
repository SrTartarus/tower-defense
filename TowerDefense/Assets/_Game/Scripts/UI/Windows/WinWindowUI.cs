using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.UI.Windows
{
    public class WinWindowUI : MonoBehaviour
    {
        #region FIELDS

        [SerializeField]
        private Button continueButton;

        #endregion

        #region BEHAVIORS

        private void Start()
        {
            continueButton.onClick.AddListener(Continue);
        }

        private void Continue()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}
