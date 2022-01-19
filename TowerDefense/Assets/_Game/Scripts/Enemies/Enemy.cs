using System.Collections.Generic;
using UnityEngine;

using Game.Enemies.Interfaces;

namespace Game.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        #region FIELDS

        [SerializeField]
        private Transform waypointsContainer;
        [SerializeField]
        private int movementSpeed = 4;
        [SerializeField]
        private int rotationSpeed = 4;

        List<Transform> waypoints = new List<Transform>();
        private int currentWaypointIndex = 1;

        #endregion

        #region BEHAVIORS

        private void Start()
        {
            foreach (Transform waypoint in waypointsContainer.transform)
                waypoints.Add(waypoint);
        }

        private void Update()
        {
            Movement();
            LookAt();
        }

        public void Dead()
        {
            throw new System.NotImplementedException();
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

        private void LookAt()
        {
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

        #endregion
    }
}
