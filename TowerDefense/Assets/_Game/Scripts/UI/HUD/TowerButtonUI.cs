using UnityEngine;
using UnityEngine.UI;

using Zenject;

using Game.Managers;

namespace Game.UI.HUD
{
    // This Class is attached to a GameObject UI
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

        // Subscring to onCoinsChanged to set interactable button
        private void Awake()
        {
            gameManager.onCoinsChanged += UpdateButton;
            towerButton = GetComponent<Button>();
            towerButton.onClick.AddListener(CreateTower);
        }

        // Setting button with default values
        private void Start()
        {
            UpdateButton();
        }

        // Creating a tower on CurrentSlot
        private void CreateTower()
        {
            buildingManager.BuildTowerOnCurrentSlot(transform.GetSiblingIndex());
            gameManager.DecreaseCoins(towerCost);
        }

        private void UpdateButton()
        {
            towerButton.interactable = gameManager.Coins >= towerCost;
        }

        // Unsubscring to onCoinsChanged to set interactable button
        private void OnDestroy()
        {
            gameManager.onCoinsChanged -= UpdateButton;
        }

        #endregion
    }
}
