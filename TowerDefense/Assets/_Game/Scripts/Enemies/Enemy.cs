using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Zenject;

using Game.Managers;
using Game.Enemies.Interfaces;
using Game.Towers.Projectiles.Enums;

namespace Game.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        #region FIELDS

        private const float FreezeDuration = 2f;
        private const float BurnDuration = 5f;
        private const float BurnDamage = 4f;

        [Inject] private GameManager gameManager;

        [Header("PROPERTIES")]
        [SerializeField]
        private float health = 100f;
        [SerializeField]
        private float movementSpeed = 4;
        [SerializeField]
        private int enemyCoins = 100;

        private float defaultMovementSpeed;
        private List<Transform> waypoints = new List<Transform>();
        private int currentWaypointIndex = 1;
        private bool isBurning = false;
        private float burnTime;

        #endregion

        #region BEHAVIORS

        private void Start()
        {
            defaultMovementSpeed = movementSpeed;
        }

        private void Update()
        {
            CheckHealth();
            Movement();

            if (isBurning)
            {
                health -= BurnDamage * Time.deltaTime;
                burnTime -= Time.deltaTime;
                if (burnTime <= 0)
                    isBurning = false;
            }
        }

        public void SetWaypointsTrace(Transform waypointsContainer)
        {
            foreach (Transform waypoint in waypointsContainer.transform)
                waypoints.Add(waypoint);
        }

        public void Damage(float damage, ProjectileEffect projectileEffect)
        {
            health -= damage;
            CheckHealth();

            switch (projectileEffect)
            {
                case ProjectileEffect.Freeze:
                    {
                        StopCoroutine(StartFreezeEffect());
                        StartCoroutine(StartFreezeEffect());
                        break;
                    }
                case ProjectileEffect.Burn:
                    {
                        isBurning = true;
                        burnTime = BurnDuration;
                        break;
                    }
            }
        }

        private IEnumerator StartFreezeEffect()
        {
            movementSpeed = defaultMovementSpeed / 2;
            yield return new WaitForSeconds(FreezeDuration);
            movementSpeed = defaultMovementSpeed;
        }

        private void Movement()
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, movementSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) <= 0.1f)
            {
                if (currentWaypointIndex >= waypoints.Count - 1)
                    return;

                currentWaypointIndex++;
            }
        }

        private void CheckHealth()
        {
            if (health <= 0.0f)
            {
                gameManager.IncreaseCoins(enemyCoins);
                Destroy(gameObject);
            }
        }

        #endregion
    }
}
