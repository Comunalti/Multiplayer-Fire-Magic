using System.Collections;
using KevinCastejon.MoreAttributes;
using ManaSystem;
using UnityEngine;

namespace AttackSystem
{
    public class AttackHandlerVerifier : MonoBehaviour
    {
        [SerializeField] [ReadOnlyOnPlay] private float manaCost;
        [SerializeField] [ReadOnlyOnPlay] private float delayTime;
        
        [SerializeField] [ReadOnlyOnPlay] private ManaController manaController;

        [SerializeField] [ReadOnly] private bool delayFinished = true;
        public bool CanAttack()
        {
            if (delayFinished && manaController.HaveEnoughMana(manaCost))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Attacked()
        {
            delayFinished = false;
            manaController.RemoveMana(manaCost);
            StartCoroutine(RestartDelay());
        }

        private IEnumerator RestartDelay()
        {
            yield return new WaitForSeconds(delayTime);
            delayFinished = true;
        }
    }
}