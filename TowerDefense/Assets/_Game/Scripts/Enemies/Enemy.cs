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

        private const float FreezeDuration = 1f;
        private const float BurnDuration = 2f;
        private const float BurnDamage = 2f;

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

        #endregion

        #region BEHAVIORS

        private void Start()
        {
            defaultMovementSpeed = movementSpeed;
        }

        private void Update()
        {
            Movement();
        }

        public void SetWaypointsTrace(Transform waypointsContainer)
        {
            foreach (Transform waypoint in waypointsContainer.transform)
                waypoints.Add(waypoint);
        }

        public void Damage(float damage, ProjectileEffect projectileEffect)
        {
            health -= damage;
            if (health <= 0.0f)
            {
                gameManager.IncreaseCoins(enemyCoins);
                Destroy(gameObject);
            }

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
                        StopCoroutine(StartBurnEffect());
                        StartCoroutine(StartBurnEffect());
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

        private IEnumerator StartBurnEffect()
        {
            float time = BurnDuration;
            while (time <= 0)
            {
                if (health <= 0.0f)
                {
                    time = 0;   
                    gameManager.IncreaseCoins(enemyCoins);
                    Destroy(gameObject);
                }

                time--;
                yield return new WaitForSeconds(1f);
                health -= BurnDamage;
            }
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

        #endregion
    }
}
