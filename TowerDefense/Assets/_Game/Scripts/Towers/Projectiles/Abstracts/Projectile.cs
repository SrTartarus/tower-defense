using UnityEngine;

using Game.Enemies;

namespace Game.Towers.Projectiles.Abstracts
{
    public abstract class Projectile : MonoBehaviour
    {
        #region FIELDS

        [SerializeField]
        protected float projectileDamage = 15f;

        protected Enemy enemy;

        #endregion

        #region PROPERTIES

        public Vector3 EnemyPosition { get => enemy.transform.position; }

        #endregion

        #region BEHAVIORS

        protected abstract void FollowTarget();

        protected virtual void Update()
        {
            if (enemy == null)
            {
                Destroy(gameObject);
                return;
            }
        }

        public void SetTarget(Enemy enemy)
        {
            this.enemy = enemy;
        }

        #endregion
    }
}
