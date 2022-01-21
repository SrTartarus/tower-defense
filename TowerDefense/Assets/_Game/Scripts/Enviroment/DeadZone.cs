using UnityEngine;

using Zenject;

using Game.Managers;

namespace Game.Enviroment
{
    public class DeadZone : MonoBehaviour
    {
        #region FIELDS

        [Inject] private GameManager gameManager;

        #endregion

        #region BEHAVIORS

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Enemy")
            {
                gameManager.DecreaseHealth();
                Destroy(other.gameObject);
            }
        }

        #endregion
    }
}
