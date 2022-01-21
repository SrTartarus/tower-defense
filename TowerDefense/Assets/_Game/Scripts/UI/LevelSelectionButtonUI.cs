using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game.UI
{
    public class LevelSelectionButtonUI : MonoBehaviour
    {
        #region FIELDS

        [SerializeField]
        private string sceneName;

        #endregion

        #region BEHAVIORS

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(ChangeScene);
        }

        private void ChangeScene()
        {
            SceneManager.LoadScene(sceneName);
        }

        #endregion
    }
}
