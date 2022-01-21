using UnityEngine;

using Zenject;

using Game.Managers;

namespace Game.Enviroment
{
    // This class is attached to a GameObject where its gameobject is the enemy's final destination
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
