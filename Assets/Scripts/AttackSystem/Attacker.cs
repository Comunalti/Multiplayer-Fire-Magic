using KevinCastejon.MoreAttributes;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace AttackSystem
{
    public class Attacker : NetworkBehaviour
    {
        [SerializeField][ReadOnlyOnPlay]private AttackHandlerVerifier attackHandlerVerifier;
        [SerializeField][ReadOnlyOnPlay]private AttackInput attackInput;
        [SerializeField][ReadOnlyOnPlay]private BulletGenerator bulletGenerator;

        public UnityEvent<GameObject> successfulAttackEvent;
        public UnityEvent failedAttackEvent;
        
        public override void OnNetworkSpawn()
        {
            if (!IsOwner)
            {
                 return;
            }

            Subscribe();
        }

        public override void OnNetworkDespawn()
        {
            
            if (!IsOwner)
            {
                return;
            }

            Unsubscribe();
        }

        private void Unsubscribe()
        {
            attackInput.attackRequestEvent.RemoveListener(OnAttackRequested);
        }

        private void Subscribe()
        {
            attackInput.attackRequestEvent.AddListener(OnAttackRequested);
        }

        private void OnAttackRequested(Vector2 mouseWorldPosition)
        {
            if (attackHandlerVerifier.CanAttack())
            {
                print("attacked");
                attackHandlerVerifier.Attacked();
                print("attacked1");

                SuccessfulAttackServerRpc(mouseWorldPosition,new ServerRpcParams{Send = new ServerRpcSendParams()});
            }
            else
            {
                print("attacked failed");

                FailedAttackServerRpc(new ServerRpcParams{Send = new ServerRpcSendParams()});
            }
        }
        [ServerRpc(RequireOwnership = true)]
        private void FailedAttackServerRpc(ServerRpcParams serverRpcParams = default)
        {
            FailedAttackClientRpc();
        }

        [ServerRpc(RequireOwnership = true)]
        private void SuccessfulAttackServerRpc(Vector2 mouseWorldPosition, ServerRpcParams serverRpcParams = default)
        {
            var clientId = serverRpcParams.Receive.SenderClientId;
            var bullet = bulletGenerator.CreateBullet(mouseWorldPosition,clientId);
            var networkObject = bullet.GetComponent<NetworkObject>();
            networkObject.Spawn(true);
            SuccessfulAttackClientRpc(networkObject,clientId);
        }

        [ClientRpc]
        private void FailedAttackClientRpc()
        {
            failedAttackEvent.Invoke();
        }

        [ClientRpc]
        private void SuccessfulAttackClientRpc(NetworkObjectReference senderClientId, ulong receiveSenderClientId, ClientRpcParams clientRpcParams = default)
        {
            if (senderClientId.TryGet(out var networkObject))
            {
                successfulAttackEvent.Invoke(networkObject.gameObject);
            }
            else
            {
                Debug.LogError("network object destroyed");
            }
        }
    }
}