using UnityEngine;

namespace Game.Enviroment
{
    public class Slot : MonoBehaviour
    {
        #region FIELDS

        [SerializeField]
        private Material selectedMaterial;
        [SerializeField]
        private Material deselectedMaterial;

        private MeshRenderer renderer;
        private int index = 0;

        #endregion

        #region PROPERTIES

        public int SlotIndex { get => index; }
        public bool HasTower { get => transform.childCount > 0; }

        #endregion

        #region BEHAVIORS

        private void Awake()
        {
            renderer = GetComponent<MeshRenderer>();
            index = transform.GetSiblingIndex();
        }

        public void SelectSlot()
        {
            renderer.material = selectedMaterial;
        }

        public void DeselectSlot()
        {
            renderer.material = deselectedMaterial;
        }

        #endregion
    }
}
