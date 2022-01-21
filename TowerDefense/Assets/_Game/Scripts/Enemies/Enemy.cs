using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Zenject;

using Game.Managers;
using Game.Enemies.Interfaces;

namespace Game.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        #region FIELDS

        private const float MagicDuration = 1f;

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

        public void Damage(float damage)
        {
            health -= damage;
            if (health <= 0.0f)
            {
                gameManager.IncreaseCoins(enemyCoins);
                Destroy(gameObject);
            }
        }

        public void AddMagicEffect()
        {
            StopAllCoroutines();
            StartCoroutine(StartMagicEffect());
        }

        private IEnumerator StartMagicEffect()
        {
            movementSpeed = defaultMovementSpeed / 2;
            yield return new WaitForSeconds(MagicDuration);
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

        #endregion
    }
}
