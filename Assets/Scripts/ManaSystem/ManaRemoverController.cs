using AttackSystem;
using UnityEngine;

namespace ManaSystem
{
    public class ManaRemoverController : MonoBehaviour
    {
        public AttackController attackController;
        public Attacker attacker;
        public ManaController manaController;
        [SerializeField] private float quantity;

        private void OnEnable()
        {
            attacker.successfulAttackEvent.AddListener(OnAttackSucceeded);
            
        }

        private void OnDisable()
        {
            attacker.successfulAttackEvent.RemoveListener(OnAttackSucceeded);

        }

        private void OnAttackSucceeded(GameObject arg0)
        {
            manaController.RemoveMana(quantity);
        }
    }
}