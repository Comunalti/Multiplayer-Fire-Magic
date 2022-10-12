using UnityEngine;

namespace Core
{
    public class AutoGameObjectDestroyer : MonoBehaviour
    {
        public float time;
        public GameObject target;
        private void Start()
        {
            Destroy(target,time);
        }
    }
}