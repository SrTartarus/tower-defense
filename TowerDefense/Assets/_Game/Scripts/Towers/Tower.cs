using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Towers.Interfaces;

namespace Game.Towers
{
    public class Tower : MonoBehaviour, ITower
    {
        #region BEHAVIORS

        [SerializeField]
        private float sphereRadius = 1f;

        private void Update()
        {
            RaycastHit hit;
            Vector3 origin = transform.position;
            Vector3 direction = transform.forward;
            if (Physics.SphereCast(origin, sphereRadius, direction, out hit))
            {
                print(hit.transform.name);
            }
        }

        public void Fire()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
