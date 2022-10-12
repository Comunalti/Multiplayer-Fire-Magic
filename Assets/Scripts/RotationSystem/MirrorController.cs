using InputSystem;
using UnityEngine;

namespace RotationSystem
{
    public class MirrorController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private Camera camera;
        [SerializeField] private Transform transform;
        private Vector2 _mousePosition; 
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

        private void Update()
        {
            var worldPoint = (Vector2)camera.ScreenToWorldPoint(_mousePosition);
            
            var distance = worldPoint - (Vector2)transform.position;

            
        }
    }
}