using UnityEngine;
using System.Collections;

using Zenject;

using Game.Enemies;

namespace Game.Managers
{
    public class WavesManager : MonoBehaviour
    {
        #region FIELDS

        [Inject] private AssetsManager assetsManager;

        [SerializeField]
        private Transform waypointsContainer;

        [SerializeField]
        private float timeBetweenWaves = 5f;

        private float countdown = 2f;
        private int waveIndex = 1;

        #endregion

        #region BEHAVIORS

        private void Update()
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                countdown = timeBetweenWaves;
                StartCoroutine(SpawnWave());
            }
        }

        private IEnumerator SpawnWave()
        {
            waveIndex++;
            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void SpawnEnemy()
        {
            GameObject enemy = Instantiate(assetsManager.EnemyPrefab, waypointsContainer.GetChild(0).position, Quaternion.identity);
            enemy.GetComponent<Enemy>().SetWaypointsTrace(waypointsContainer);
        }

        #endregion
    }
}
