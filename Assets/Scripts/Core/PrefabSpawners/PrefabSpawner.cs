using UnityEngine;

namespace Core
{
    public class PrefabSpawner : MonoBehaviour
    {
        public GameObject prefab;
        public Transform root;

        public bool followRotation = false;
        
        public void SpawnPrefab()
        {
            var rot = followRotation ? transform.rotation : Quaternion.identity;
            Instantiate(prefab, root.position, rot);
        }
    }
}