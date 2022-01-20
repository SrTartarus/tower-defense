using UnityEngine;

namespace Game.Managers
{
    public class AssetsManager : MonoBehaviour
    {
        #region FIELDS

        [SerializeField]
        private GameObject enemyPrefab;

        [SerializeField]
        private GameObject projectileArrowPrefab;
        

        #endregion

        #region PROPERTIES

        public GameObject EnemyPrefab { get => enemyPrefab; }
        public GameObject ProjectileArrowPrefab { get => projectileArrowPrefab; }

        #endregion
    }
}
