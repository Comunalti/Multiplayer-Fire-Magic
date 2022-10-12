using InputSystem;
using Unity.Netcode;
using UnityEngine;

namespace MovementSystem
{
    public class MovementController : NetworkBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private Transform transform;
        [SerializeField] private float speed = 1;
        
        private Vector2 _direction;
        private void OnEnable()
        {
            inputManager.DirectionChangedEvent += OnDirectionChangedEvent;
        }

        private void OnDisable()
        {
            inputManager.DirectionChangedEvent -= OnDirectionChangedEvent;
        }

        public override void OnNetworkSpawn()
        {
            enabled = IsOwner;
        }

        private void Update()
        {
            if (!IsOwner)
            {
                return;
            }
            transform.position = transform.position + (Vector3)_direction * (speed * Time.deltaTime);
        }

        private void OnDirectionChangedEvent(Vector2 obj)
        {
            _direction = obj;
        }
    }
}