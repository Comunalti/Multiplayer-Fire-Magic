using Core;
using ManaSystem;
using UnityEngine;

namespace HealthSystem
{
    public class LowManaHealthRemover : MonoBehaviour
    {
        [SerializeField] private ManaController manaController;
        [SerializeField] private HealthController healthController;
        private bool isOnMaxMana;
        [SerializeField] private float quantity = 1;
        public EventFlags _eventFlags = EventFlags.RefreshUi;

        private void OnEnable()
        {
            manaController.manaEventHandler.manaChangedEvent.AddListener(OnManaChanged);
        }

        private void OnDisable()
        {
            manaController.manaEventHandler.manaChangedEvent.RemoveListener(OnManaChanged);
        }

        private void OnManaChanged()
        {
            isOnMaxMana = manaController.isManaMaxed;
        }

        private void Update()
        {
            if (isOnMaxMana)
            {
                healthController.RemoveHealth(_eventFlags,quantity * Time.deltaTime);
            }
        }
    }
}