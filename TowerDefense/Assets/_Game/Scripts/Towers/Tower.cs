using System.Linq;
using UnityEngine;

using Zenject;

using Game.Managers;
using Game.Enemies;
using Game.Towers.Projectiles.Abstracts;

namespace Game.Towers
{
    // This class is attached to a Tower GameObject prefab
    public class Tower : MonoBehaviour
    {
        #region BEHAVIORS

        [Inject] private WavesManager wavesManager;

        [SerializeField]
        private GameObject projectilePrefab;

        [SerializeField]
        private float range = 15f;
        [SerializeField]
        private float shootRate = 0.1f;
        [SerializeField]
        private LayerMask ignoreLayer;

        private Transform target;
        private float shootTimer;

        private void Start()
        {
            InvokeRepeating("FindTarget", 0, 0.5f);
        }

        private void Update()
        {
            if (target == null)
            {
                shootTimer = 0f;
                return;
            }

            // Shooting with a fire rate
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                shootTimer = shootRate;
                CreateProjectile(target);
            }
        }

        // Finding a new target to shoot
        private void FindTarget()
        {
            Transform[] enemies = wavesManager.EnemiesContainer.Cast<Transform>().ToArray();
            float shortestDistance = Mathf.Infinity;
            Transform nearestEnemy = null;
            foreach (Transform enemy in enemies)
            {
                if (HasLayer(ignoreLayer, enemy.gameObject.layer))
                    continue;

                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= range)
                target = nearestEnemy.transform;
            else
                target = null;
        }

        // Instantiate a new Projectile
        private void CreateProjectile(Transform enemy)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().SetTarget(enemy.GetComponent<Enemy>());
        }

        // Ignoring enemies with a Magic Inmune layer
        private bool HasLayer(LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }

        #endregion
    }
}
