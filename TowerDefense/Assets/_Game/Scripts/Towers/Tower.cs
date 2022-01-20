using UnityEngine;

using Zenject;

using Game.Managers;
using Game.Enemies;
using Game.Towers.Interfaces;
using Game.Towers.Projectiles;

namespace Game.Towers
{
    public class Tower : MonoBehaviour, ITower
    {
        #region BEHAVIORS

        [Inject] private AssetsManager assetManager;

        [SerializeField]
        private float sphereRadius = 1f;

        private float shootRate = 0.1f;
        private float shootTimer;

        private void Update()
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                shootTimer = shootRate;
                RaycastHit hit;
                Vector3 origin = transform.position;
                Vector3 direction = transform.forward;
                if (Physics.SphereCast(origin, sphereRadius, direction, out hit))
                {
                    GameObject projectile = Instantiate(assetManager.ProjectileArrowPrefab, transform.position, Quaternion.identity);
                    projectile.GetComponent<ArrowProjectile>().SetTarget(hit.transform.GetComponent<Enemy>());
                }
            }
        }

        public void Fire()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
