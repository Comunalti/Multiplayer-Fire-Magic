using UnityEngine;

namespace Core
{
    public class AutoComponentDestroyer : MonoBehaviour
    {
        public float time;
        public Component target;
        private void Start()
        {
            Destroy(target,time);
        }
    }
}