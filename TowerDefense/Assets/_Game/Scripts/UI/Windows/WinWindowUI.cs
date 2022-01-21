using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.UI.Windows
{
    // This class is a congralution window
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

        // Pressing continue button will go back to Map
        private void Continue()
        {
            SceneManager.LoadScene("Map");
        }

        #endregion
    }
}
