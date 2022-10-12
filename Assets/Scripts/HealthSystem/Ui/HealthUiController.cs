using UnityEngine;
using UnityEngine.UI;

namespace HealthSystem
{
    public class HealthUiController : MonoBehaviour
    {
        public HealthController healthController;
        public Image image;
            
        private void OnEnable()
        {
            healthController.eventHandler.healthChangedUiEvent.AddListener(OnHealthChanged);
        }

        private void OnDisable()
        {
            healthController.eventHandler.healthChangedUiEvent.RemoveListener(OnHealthChanged);
        }

        private void OnHealthChanged()
        {
            
            print("update ui");
            image.fillAmount = healthController.Percentage;
            
        }
    }
}