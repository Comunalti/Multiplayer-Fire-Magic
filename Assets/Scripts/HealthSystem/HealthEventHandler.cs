using System;
using Core;
using UnityEngine.Events;

namespace HealthSystem
{
    [Serializable]
    public class HealthEventHandler
    {
        public UnityEvent<EventFlags> changedEvent;
        public UnityEvent healthChangedUiEvent;
        public UnityEvent healthChangedParticlesEvent;
        public UnityEvent healthChangedSoundEvent;
        public UnityEvent deathEvent;
        public UnityEvent failToHealEvent;
        public UnityEvent failToDamageEvent;

        public void HealthChanged(EventFlags eventFlags,float current,float quantity)
        {
            changedEvent.Invoke(eventFlags);
            
            if (eventFlags.HasFlag(EventFlags.Particles))
            {
                healthChangedParticlesEvent.Invoke();    
            }
            if (eventFlags.HasFlag(EventFlags.RefreshUi))
            {
                healthChangedUiEvent.Invoke();    
            }
            if (eventFlags.HasFlag(EventFlags.Sound))
            {
                healthChangedSoundEvent.Invoke();    
            }

        }

       
    }
}