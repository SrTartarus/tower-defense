using UnityEngine;
using UnityEngine.Events;

namespace Game.Managers
{
    // This Manager has authority to handle gameplay variables
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

        // Events to call changes on UI
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

        // Appearing Congratulations Window
        public void PlayerWon()
        {
            onPlayerWon?.Invoke();
        }

        // Decreasing health and updating UI
        public void DecreaseHealth()
        {
            if (health <= 0)
                return;

            health--;
            onHealthDecreased?.Invoke();
            if (health <= 0)
                onPlayerLose?.Invoke();
        }

        // Increasing coins and updating UI
        public void IncreaseCoins(int quantity)
        {
            coins += quantity;
            onCoinsChanged?.Invoke();
        }

        // Decreasing coins and updating UI
        public void DecreaseCoins(int quantity)
        {
            coins -= quantity;
            onCoinsChanged?.Invoke();
        }

        #endregion
    }
}

