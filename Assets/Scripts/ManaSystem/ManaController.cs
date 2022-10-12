using System;
using UnityEngine;
using UnityEngine.Events;

namespace ManaSystem
{
    [Serializable]
    public class ManaEventHandler
    {
        public UnityEvent manaChangedEvent;
        
        public UnityEvent reachMaxManaEvent;
        public UnityEvent leaveMaxManaEvent;
        public UnityEvent reachCriticEvent;
        public UnityEvent leaveCriticEvent;
    }

    public class ManaController : MonoBehaviour
    {
        [Range(0,1)] public float criticPercentage = 0.7f;
        [Min(0)] public float currentMana;
        [Min(0)] public float maxMana;
        public bool isOnCritic;
        public bool isManaMaxed;
        public float Percentage => currentMana / maxMana;

       

        public ManaEventHandler manaEventHandler = new ManaEventHandler();
        private bool _wasManaMaxed;

        private void Validate()
        {
            currentMana = Mathf.Clamp(currentMana, 0, maxMana);

            isManaMaxed = Math.Abs(currentMana - maxMana) < 0.001f;;
            if (isManaMaxed && !_wasManaMaxed)
            {
                manaEventHandler.reachMaxManaEvent.Invoke();
            }else if(!isManaMaxed && _wasManaMaxed)
            {
                manaEventHandler.leaveMaxManaEvent.Invoke();
            }
            _wasManaMaxed = isManaMaxed;

            var critic = (Percentage >= criticPercentage);
            if (critic && !isOnCritic)
            {
                isOnCritic = true;
                manaEventHandler.reachCriticEvent.Invoke();
            }else if (!critic && isOnCritic)
            {
                isOnCritic = false;
                manaEventHandler.leaveCriticEvent.Invoke();
            }

            manaEventHandler.manaChangedEvent.Invoke();
        }
        
        public void AddMana(float quantity = 1)
        {
            currentMana += quantity;
            Validate();
        }

        public void RemoveMana(float quantity = 1)
        {
            currentMana -= quantity;
            Validate();
        }

        public bool HaveEnoughMana(float quantity = 1)
        {
            return currentMana > quantity;
        }
    }
}