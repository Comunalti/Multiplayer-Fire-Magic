using HealthSystem;
using InputSystem;
using KevinCastejon.MoreAttributes;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

namespace AttackSystem
{
    public class AttackInput : NetworkBehaviour
    {
        public UnityEvent<Vector2> attackRequestEvent;
        
        [SerializeField] [ReadOnlyOnPlay] private InputManager inputManager;
        
        [SerializeField] [ReadOnly] private Vector2 _mouseScreenPosition;
        [SerializeField] [ReadOnly] private Vector2 _mouseWorldPosition;
        public void OnEnable()
        {
            inputManager.MouseLeftButtonClickedEvent += OnMouseLeftButtonClicked;
            inputManager.MousePositionChangedEvent += OnMousePositionChanged;
        }

        public void OnDisable()
        {
            inputManager.MouseLeftButtonClickedEvent -= OnMouseLeftButtonClicked;
            inputManager.MousePositionChangedEvent -= OnMousePositionChanged;
        }
        
        private void OnMousePositionChanged(Vector2 obj)
        {
            if (!IsOwner)
                return;
            
            _mouseScreenPosition = obj;
            _mouseWorldPosition = LocalPlayerManager.instance.camera.ScreenToWorldPoint(_mouseScreenPosition);
        }
        
        private void OnMouseLeftButtonClicked()
        {
            if (!IsOwner)
                return;
            
            attackRequestEvent.Invoke(_mouseWorldPosition);
        }
    }
}