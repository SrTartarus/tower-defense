using UnityEngine;
using UnityEngine.Events;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region FIELDS

        [Header("PROPERTIES")]
        [SerializeField]
        private int health = 20;

        [SerializeField]
        private int coins = 150;

        #endregion

        #region EVENTS

        public event UnityAction onHealthDecreased;
        public event UnityAction onCoinsChanged;
        public event UnityAction onPlayerWon;
        public event UnityAction onPlayerLose;

        #endregion

        #region PROPERTIES

        public int Health { get => health; }
        public int Coins { get => coins; }

        #endregion

        #region BEHAVIORS

        public void PlayerWon()
        {
            onPlayerWon?.Invoke();
        }

        public void DecreaseHealth()
        {
            if (health <= 0)
                return;

            health--;
            onHealthDecreased?.Invoke();
            if (health <= 0)
                onPlayerLose?.Invoke();
        }

        public void IncreaseCoins(int quantity)
        {
            coins += quantity;
            onCoinsChanged?.Invoke();
        }

        public void DecreaseCoins(int quantity)
        {
            coins -= quantity;
            onCoinsChanged?.Invoke();
        }

        #endregion
    }
}

