using UnityEngine;

using Game.Towers.Projectiles.Abstracts;

namespace Game.Towers.Projectiles
{
    public class CannonBallProjectile : Projectile
    {
        #region FIELDS

        private Rigidbody rigidBody;

        #endregion

        #region BEHAVIORS

        private void Start()
        {
            rigidBody = transform.GetComponent<Rigidbody>();
        }

        protected override void Update()
        {
            base.Update();
            FollowTarget();
        }

        protected override void FollowTarget()
        {
            rigidBody.velocity = BallisticVelocityVector(EnemyPosition, 40);
        }

        Vector3 BallisticVelocityVector(Vector3 targetPosition, float angle)
        {
            Vector3 direction = targetPosition - transform.position;
            float h = direction.y;
            direction.y = 0;
            float distance = direction.magnitude;
            float a = angle * Mathf.Deg2Rad;
            direction.y = distance * Mathf.Tan(a);
            distance += h / Mathf.Tan(a);
            float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
            return velocity * direction.normalized;
        }

        #endregion
    }
}

