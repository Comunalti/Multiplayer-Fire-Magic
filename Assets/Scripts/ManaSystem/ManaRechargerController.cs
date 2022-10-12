using UnityEngine;

namespace ManaSystem
{
    public class ManaRechargerController : MonoBehaviour
    {
        [SerializeField] private ManaController manaController;

        [SerializeField] private float quantity;
        private void Update()
        {
            manaController.AddMana(quantity*Time.deltaTime);
        }
    }
}