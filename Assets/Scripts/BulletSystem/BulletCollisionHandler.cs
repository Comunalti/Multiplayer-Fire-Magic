using Core;
using HealthSystem;
using UnityEngine;

namespace BulletSystem
{
    public class BulletCollisionHandler : MonoBehaviour
    {
        public GameObject prefab;
        public Transform root;
        [SerializeField] private float damage;
        [SerializeField] private EventFlags eventFlags;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.gameObject.CompareTag("Player"))
            {
                var health = col.collider.GetComponentInChildren<HealthController>();
                
                health.RemoveHealth(eventFlags,damage);
                Destroy(root.gameObject);
            }
            else
            {
                Vector2 transformRight = root.right;
                var vector2 = col.GetContact(0).normal;
                var reflect = Vector2.Reflect(transformRight, vector2);
                root.right = reflect;

                Instantiate(prefab, root.position, Quaternion.identity);
            }
            
        }
    }
}