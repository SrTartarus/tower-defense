using UnityEngine;

using Game.Enemies;

namespace Game.Towers.Projectiles
{
    public class ArrowProjectile : MonoBehaviour
    {
        #region FIELDS

        [SerializeField]
        private float projectileDamage = 15f;

        private Enemy enemyTarget;

        #endregion

        #region PROPERTIES

        private Vector3 EnemyPosition { get => enemyTarget.transform.position; }

        #endregion

        #region BEHAVIORS

        private void Update()
        {
            if (enemyTarget == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 moveDirection = (EnemyPosition - transform.position).normalized;
            float moveSpeed = 60f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            float destroySelfDistance = 1f;
            if (Vector3.Distance(transform.position, EnemyPosition) < destroySelfDistance)
            {
                enemyTarget.Damage(projectileDamage);
                Destroy(gameObject);
            }
        }

        public void SetTarget(Enemy enemyTarget)
        {
            this.enemyTarget = enemyTarget;
        }

        #endregion
    }
}
