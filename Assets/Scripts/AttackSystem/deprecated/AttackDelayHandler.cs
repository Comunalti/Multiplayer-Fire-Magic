using System.Collections;
using UnityEngine;

namespace AttackSystem
{
    public class AttackDelayHandler : MonoBehaviour
    {
        [SerializeField] private float attackDelay = 0;
        private bool canAttack = true;

        public bool CanAttack()
        {
            return canAttack;
        }

        public void Attack()
        {
            canAttack = false;
            StartCoroutine(ResetCanAttack());
        }

        private IEnumerator ResetCanAttack()
        {
            yield return new WaitForSeconds(attackDelay);
            canAttack = true;
        }
    }
}