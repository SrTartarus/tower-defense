using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Managers
{
    public class AssetsManager : MonoBehaviour
    {
        #region FIELDS

        [SerializeField]
        private GameObject projectileArrowPrefab;

        #endregion

        #region PROPERTIES

        public GameObject ProjectileArrowPrefab { get => projectileArrowPrefab; }

        #endregion
    }
}
