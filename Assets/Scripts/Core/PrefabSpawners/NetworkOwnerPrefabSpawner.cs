using Unity.Netcode;
using UnityEngine;

namespace Core
{
    public class NetworkOwnerPrefabSpawner : NetworkBehaviour
    {
        public GameObject prefab;
        public Transform root;

        public bool followRotation = false;
        [ServerRpc(RequireOwnership = true)]
        public void SpawnPrefabServerRpc()
        {
            var rot = followRotation ? transform.rotation : Quaternion.identity;
            var o = Instantiate(prefab, root.position, rot);
            var networkObject = o.GetComponentInChildren<NetworkObject>();
            networkObject.Spawn();
        }
    }
}