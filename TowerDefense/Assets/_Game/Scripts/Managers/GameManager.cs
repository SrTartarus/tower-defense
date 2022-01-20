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

        #endregion

        #region EVENTS

        public event UnityAction onHealthDecreased;
        public event UnityAction onPlayerWon;
        public event UnityAction onPlayerLose;

        #endregion

        #region PROPERTIES

        public int Health { get => health; }

        #endregion

        #region BEHAVIORS

        public void PlayerWon()
        {
            onPlayerWon?.Invoke();
        }

        public void DecreaseHealth()
        {
            health--;
            onHealthDecreased?.Invoke();
            if (health <= 0)
                onPlayerLose?.Invoke();
        }

        #endregion
    }
}

