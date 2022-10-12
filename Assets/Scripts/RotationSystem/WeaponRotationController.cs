using HealthSystem;
using InputSystem;
using Unity.Netcode;
using UnityEngine;

namespace RotationSystem
{
    public class WeaponRotationController : NetworkBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private Transform transform;
        private Vector2 _mousePosition;
        [SerializeField] private Transform playerRoot;
        
        private void OnEnable()
        {
            inputManager.MousePositionChangedEvent += OnMousePositionChanged;
        }

        private void OnDisable()
        {
            inputManager.MousePositionChangedEvent -= OnMousePositionChanged;
        }

        private void OnMousePositionChanged(Vector2 obj)
        {
            _mousePosition = obj;
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
            var worldPoint = (Vector2)LocalPlayerManager.instance.camera.ScreenToWorldPoint(_mousePosition);
            
            var distance = worldPoint - (Vector2)transform.position;

            
            if (distance.x < 0)
            {
                playerRoot.rotation = Quaternion.Euler(0,180,0);
                distance.x = Mathf.Abs(distance.x);
                transform.right = distance.normalized;
                var eulerAngles = transform.localEulerAngles;
                eulerAngles.y = 0;
                transform.localEulerAngles = eulerAngles;
            }
            else
            {
                playerRoot.rotation = Quaternion.Euler(0,0,0);
                transform.right = distance.normalized;
            }
            
        }
    }
}