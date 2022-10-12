using Core;
using Unity.Netcode;
using UnityEngine;

namespace HealthSystem
{
    public class HealthController : NetworkBehaviour
    {
        public float currentHealth;
        public float maxHealth;

        [SerializeField] public HealthEventHandler eventHandler = new HealthEventHandler();
        public float Percentage => currentHealth / maxHealth;
        public bool isDead;

        private void Validate()
        {
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            if (currentHealth == 0)
            {
                isDead = true;
                eventHandler.deathEvent.Invoke();
            }
        }

        public void RemoveHealth(EventFlags eventFlags, float quantity = 1)
        {
            if (!IsOwner)
            {
                return;
            }

            RemoveHealthServerRpc(eventFlags,quantity);
        }

        [ServerRpc]
        public void RemoveHealthServerRpc(EventFlags eventFlags, float quantity = 1)
        {
            RemoveHealthClientRpc(eventFlags, quantity);
        }
        
        [ClientRpc]
        public void RemoveHealthClientRpc(EventFlags eventFlags, float quantity = 1)
        {
            if (isDead)
            {
                eventHandler.failToDamageEvent.Invoke();
                return;
            }
            currentHealth -= quantity;
            Validate();
            eventHandler.HealthChanged(eventFlags,currentHealth,quantity);
        }

        [ServerRpc]
        public void AddHealthServerRpc(EventFlags eventFlags, float quantity = 1)
        {
            AddHealthClientRpc(eventFlags,quantity);
        }
        
        [ClientRpc]
        public void AddHealthClientRpc(EventFlags eventFlags, float quantity = 1)
        {
            if (isDead)
            {
                eventHandler.failToHealEvent.Invoke();
                return;
            }
            currentHealth += quantity;
            Validate();
            eventHandler.HealthChanged(eventFlags,currentHealth,quantity);
        }
    }

}