using UnityEngine;

namespace BulletSystem
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 1;
        private void Update()
        {
            transform.position = transform.position + transform.right * (speed * Time.deltaTime);
        }
        
        
    }
}