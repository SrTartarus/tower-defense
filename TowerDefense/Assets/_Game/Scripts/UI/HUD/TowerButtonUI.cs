using UnityEngine;
using UnityEngine.UI;

using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
    public class TowerButtonUI : MonoBehaviour
    {
        #region FIELDS

        [Inject] private GameManager gameManager;
        [Inject] private BuildingManager buildingManager;

        [SerializeField]
        private int towerCost;

        private Button towerButton;

        #endregion

        #region BEHAVIORS

        private void Awake()
        {
            gameManager.onCoinsChanged += UpdateButton;
            towerButton = GetComponent<Button>();
            towerButton.onClick.AddListener(CreateTower);
        }

        private void Start()
        {
            UpdateButton();
        }

        private void CreateTower()
        {
            buildingManager.BuildTowerOnCurrentSlot(transform.GetSiblingIndex());
            gameManager.DecreaseCoins(towerCost);
        }

        private void UpdateButton()
        {
            towerButton.interactable = gameManager.Coins >= towerCost;
        }

        private void OnDestroy()
        {
            gameManager.onCoinsChanged -= UpdateButton;
        }

        #endregion
    }
}
