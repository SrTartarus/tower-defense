using UnityEngine;

using Game.Enemies;
using Game.Towers.Projectiles.Abstracts;

namespace Game.Towers
{
    public class Tower : MonoBehaviour
    {
        #region BEHAVIORS

        [SerializeField]
        private GameObject projectilePrefab;

        [SerializeField]
        private float sphereRadius = 1f;
        [SerializeField]
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
                    CreateProjectile(hit.transform);
            }
        }

        private void CreateProjectile(Transform enemy)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.GetChild(0).position, Quaternion.identity);
            projectile.GetComponent<Projectile>().SetTarget(enemy.GetComponent<Enemy>());
        }

        #endregion
    }
}
