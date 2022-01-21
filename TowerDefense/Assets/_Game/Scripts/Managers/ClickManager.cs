using UnityEngine;
using UnityEngine.EventSystems;

using Zenject;

using Game.Enviroment;

namespace Game.Managers
{
    public class ClickManager : MonoBehaviour
    {
        #region FIELDS

        [Inject] private BuildingManager buildingManager;

        [SerializeField]
        private LayerMask clickableLayer;

        private Transform currentObject;

        #endregion

        #region BEHAVIORS

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit rayHit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, clickableLayer))
                {
                    if (rayHit.collider.tag == "Clickable" && !EventSystem.current.IsPointerOverGameObject())
                    {
                        CleanLastObject();
                        var slot = rayHit.transform.GetComponent<Slot>();
                        if (slot.HasTower)
                            return;

                        currentObject = rayHit.transform;
                        currentObject.GetComponent<Slot>().SelectSlot();
                        buildingManager.EnableInventory(slot.SlotIndex);
                    }
                }
                else
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                        CleanLastObject();
                }
            }
        }

        public void CleanLastObject()
        {
            if (!currentObject)
                return;

            currentObject.GetComponent<Slot>().DeselectSlot();
            buildingManager.DisableInventory();
        }

        #endregion
    }
}
