using UnityEngine;

namespace ManaSystem
{
    public class ManaUiController : MonoBehaviour
    {
        public ManaController manaController;

        public RectTransform rectTransform;
        [SerializeField] private float maxSize;

        private void OnEnable()
        {
            manaController.manaEventHandler.manaChangedEvent.AddListener(OnManaChanged);
        }
        private void OnDisable()
        {
            manaController.manaEventHandler.manaChangedEvent.RemoveListener(OnManaChanged);
        }

        private void Start()
        {
            OnManaChanged();
        }

        private void OnManaChanged()
        {
            var sizeDelta = rectTransform.sizeDelta;
            sizeDelta.x = manaController.Percentage * maxSize;
            rectTransform.sizeDelta = sizeDelta;
        }
    }
}