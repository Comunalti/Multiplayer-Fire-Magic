using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    public class InputManager : NetworkBehaviour, InputMap.IMovimentActions, InputMap.IMouseActions
    {
        private InputMap _inputMap;

        public event Action<Vector2> DirectionChangedEvent;
        public event Action<Vector2> MousePositionChangedEvent;

        public event Action MouseLeftButtonClickedEvent;

        public override void OnNetworkSpawn()
        {
            enabled = IsOwner;
        }

        public override void OnNetworkDespawn()
        {
            base.OnNetworkDespawn();
        }

        private void OnEnable()
        {
            if (_inputMap is null)
            {
                _inputMap = new InputMap();
            }
            _inputMap.Enable();
        }

        private void OnDisable()
        {
            _inputMap.Disable();
        }

        private void Awake()
        {
            _inputMap = new InputMap();
            _inputMap.Mouse.SetCallbacks(this);
            _inputMap.Moviment.SetCallbacks(this);
        }

        public void OnWalk(InputAction.CallbackContext context)
        {
            DirectionChangedEvent?.Invoke(context.ReadValue<Vector2>());
            //print(context.ReadValue<Vector2>());
        }

        public void OnPosition(InputAction.CallbackContext context)
        {
            MousePositionChangedEvent?.Invoke(context.ReadValue<Vector2>());
            //print(context.ReadValue<Vector2>());

        }
        

        public void OnMouseLeftClick(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                MouseLeftButtonClickedEvent?.Invoke();
            }
        }
    }
}