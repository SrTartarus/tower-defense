using UnityEngine;
using System.Collections.Generic;

using Zenject;

namespace Game.Managers
{
    // This is manager enables inventory UI where player can build new towers on each slot
    public class BuildingManager : MonoBehaviour
    {
        #region FIELDS

        [Inject] private ClickManager clickManager;

        [SerializeField]
        private List<GameObject> towersPrefab;

        [SerializeField]
        private GameObject inventoryObject;

        [SerializeField]
        private Transform slotsContainer;

        private int currentSlotIndex;
        private List<Transform> slots = new List<Transform>();

        #endregion

        #region BEHAVIORS

        private void Awake()
        {
            foreach(Transform slot in slotsContainer)
                slots.Add(slot);
        }

        // Builiding from UI a new Tower
        public void BuildTowerOnCurrentSlot(int towerIndex)
        {
            GameObject tower = Instantiate(towersPrefab[towerIndex], slots[currentSlotIndex]);
            tower.transform.rotation = slots[currentSlotIndex].rotation;
            clickManager.CleanLastObject();
        }

        // Enable inventory tower UI
        public void EnableInventory(int index)
        {
            currentSlotIndex = index;
            inventoryObject.SetActive(true);
        }

        // Disable inventory tower UI
        public void DisableInventory()
        {
            inventoryObject.SetActive(false);
        }

        #endregion
    }
}
