using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

using Zenject;

using Game.Enemies;

namespace Game.Managers
{
    // This Class can create waves of enemies
    public class WavesManager : MonoBehaviour
    {
        #region FIELDS

        [Inject] private GameManager gameManager;

        [Header("SETTINGS")]
        [SerializeField]
        private List<GameObject> enemiesPrefab;

        [SerializeField]
        private Transform waypointsContainer;

        [SerializeField]
        private Transform enemiesContainer;

        [Header("PROPERTIES")]
        [SerializeField]
        private float timeBetweenWaves = 10f;

        [SerializeField]
        private int maximumWaves = 20;

        private float countdown = 10f;
        private int wavesNumber = 1;
        private bool isFirstWaveStarted = false;
        private bool isAllWavesCompleted = false;

        #endregion

        #region EVENTS

        public event UnityAction<int> onWaveStarted;

        #endregion

        #region PROPERTIES

        public Transform EnemiesContainer { get => enemiesContainer; }
        public int WaveCountDown { get => (int)countdown; }
        public int MaximumWaves { get => maximumWaves; }

        #endregion

        #region BEHAVIORS

        private void Update()
        {
            if (isAllWavesCompleted)
                return;

            // Checking multiples condition
            // 1.- if all enemies were died
            // 2.- check if player has completed all waves
            // 2.- if we start the first wave
            if (enemiesContainer.childCount <= 0 && isFirstWaveStarted && wavesNumber > maximumWaves)
            {
                isAllWavesCompleted = true;
                gameManager.PlayerWon();
            }

            // Checking for a new wave
            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                countdown = timeBetweenWaves;
                onWaveStarted?.Invoke(wavesNumber);
                StartCoroutine(SpawnWave());
            }
        }

        // Spawn a new wave of enemies
        private IEnumerator SpawnWave()
        {
            isFirstWaveStarted = true;
            for (int i = 0; i < wavesNumber; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }

            wavesNumber++;
        }

        // Instantiate a enemy prefab
        private void SpawnEnemy()
        {
            var random = Random.Range(0, enemiesPrefab.Count);
            var randomTrace = Random.Range(0, waypointsContainer.childCount);
            GameObject enemy = Instantiate(enemiesPrefab[random], waypointsContainer.GetChild(randomTrace).GetChild(0).position, Quaternion.identity, enemiesContainer);
            enemy.GetComponent<Enemy>().SetWaypointsTrace(waypointsContainer.GetChild(randomTrace));
        }

        #endregion
    }
}
