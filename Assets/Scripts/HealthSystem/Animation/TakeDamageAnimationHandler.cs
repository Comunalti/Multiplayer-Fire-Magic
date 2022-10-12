using System.Collections;
using UnityEngine;

namespace HealthSystem
{
    public class TakeDamageAnimationHandler : MonoBehaviour
    {
        public int flashQuantity;
        public float flashDuration;
        public SpriteRenderer spriteRenderer;
        [SerializeField] private Material whiteMaterial;
        private Material _defaultMaterial;


        [ContextMenu("flash")]
        public void Flash()
        {
            StartCoroutine(FlashCoroutine());
        }

        private void Start()
        {
            _defaultMaterial = spriteRenderer.material;
        }

        private IEnumerator FlashCoroutine()
        {
            var wait = new WaitForSeconds(flashDuration);
            
            for (int i = 0; i < flashQuantity * 2; i++)
            {
                yield return wait;
                if (i%2==0)
                {
                    spriteRenderer.material = whiteMaterial;
                }
                else
                {
                    spriteRenderer.material = _defaultMaterial;
                }
            }
        }

    }
}