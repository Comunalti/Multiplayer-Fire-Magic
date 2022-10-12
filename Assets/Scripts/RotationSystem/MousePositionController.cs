using InputSystem;
using UnityEngine;

namespace RotationSystem
{
    public class MousePositionController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private Transform transform;
        public Vector2 mousePosition; 
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
            mousePosition = obj;
            transform.position = mousePosition;
        }
    }
}