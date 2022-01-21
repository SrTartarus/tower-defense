using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Zenject;

using Game.Managers;
using Game.Enemies.Interfaces;
using Game.Towers.Projectiles.Enums;

namespace Game.Enemies
{
    // This class is attached to a Enemy GameObject prefab
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
            // Check if player has not health
            CheckHealth();
            // Enemy movement
            Movement();

            // Enemy starts burning
            if (isBurning)
            {
                health -= BurnDamage * Time.deltaTime;
                burnTime -= Time.deltaTime;
                if (burnTime <= 0)
                    isBurning = false;
            }
        }

        // Set wich way enemy needs to follow
        public void SetWaypointsTrace(Transform waypointsContainer)
        {
            foreach (Transform waypoint in waypointsContainer.transform)
                waypoints.Add(waypoint);
        }

        // Taking damage with our without effect
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

        // Enemy starts freezing (movement speed reduced)
        private IEnumerator StartFreezeEffect()
        {
            movementSpeed = defaultMovementSpeed / 2;
            yield return new WaitForSeconds(FreezeDuration);
            movementSpeed = defaultMovementSpeed;
        }

        // Enemey movement
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

        // Check if player has not health
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
