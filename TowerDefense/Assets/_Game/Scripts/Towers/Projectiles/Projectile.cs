using UnityEngine;

using Game.Enemies;
using Game.Towers.Projectiles.Enums;

namespace Game.Towers.Projectiles.Abstracts
{
    // This class is attached to a Projectile GameObject prefab
    public class Projectile : MonoBehaviour
    {
        #region FIELDS

        [SerializeField]
        private ProjectileEffect projectileEffect;

        [SerializeField]
        private float projectileDamage = 15f;

        [SerializeField]
        private float projectileSpeed = 60f;

        protected Enemy enemy;

        #endregion

        #region PROPERTIES

        public Vector3 EnemyPosition { set; get; }

        #endregion

        #region BEHAVIORS

        private void Update()
        {
            if (enemy == null)
            {
                Destroy(gameObject);
                return;
            }

            // Follow the nearest enemy target found
            FollowTarget();
        }

        // Setting the nearest enemy target
        public void SetTarget(Enemy enemy)
        {
            this.enemy = enemy;
            Vector3 enemyPosition = enemy.transform.position;
            EnemyPosition = new Vector3(enemyPosition.x, enemyPosition.y, enemyPosition.z);
        }

        // Follow the nearest enemy target found
        private void FollowTarget()
        {
            Vector3 moveDirection = (EnemyPosition - transform.position).normalized;
            transform.position += moveDirection * projectileSpeed * Time.deltaTime;
            float destroySelfDistance = 1f;
            if (Vector3.Distance(transform.position, EnemyPosition) < destroySelfDistance)
            {
                enemy.Damage(projectileDamage, projectileEffect);
                Destroy(gameObject);
            }
        }

        #endregion
    }
}
