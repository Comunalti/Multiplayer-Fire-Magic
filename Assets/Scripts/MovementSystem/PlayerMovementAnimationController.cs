using InputSystem;
using UnityEngine;

namespace MovementSystem
{
    public class PlayerMovementAnimationController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private MovementAnimationHandler movementAnimationHandler;
        private void OnEnable()
        {
            inputManager.DirectionChangedEvent += OnDirectionChanged;
        }
        private void OnDisable()
        {
            inputManager.DirectionChangedEvent -= OnDirectionChanged;
        }
        
        private void OnDirectionChanged(Vector2 obj)
        {
            if (obj == Vector2.zero)
            {
                movementAnimationHandler.StopSequence();
            }
            else
            {
                movementAnimationHandler.StartSequence();
            }
        }
        
    }
}