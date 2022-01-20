using UnityEngine;

using Game.Towers.Projectiles.Abstracts;

namespace Game.Towers.Projectiles
{
    public class ArrowProjectile : Projectile
    {
        #region BEHAVIORS

        protected override void Update()
        {
            base.Update();
            FollowTarget();
        }

        protected override void FollowTarget()
        {
            Vector3 moveDirection = (EnemyPosition - transform.position).normalized;
            float moveSpeed = 60f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            float destroySelfDistance = 1f;
            if (Vector3.Distance(transform.position, EnemyPosition) < destroySelfDistance)
            {
                enemy.Damage(projectileDamage);
                Destroy(gameObject);
            }
        }

        #endregion
    }
}
