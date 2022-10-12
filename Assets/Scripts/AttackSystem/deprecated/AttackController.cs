using InputSystem;
using ManaSystem;
using UnityEngine;
using UnityEngine.Events;

namespace AttackSystem
{
    public class AttackController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private Camera camera;
        [SerializeField] private Transform weaponGemTransform;
        private Vector2 _mousePosition;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject particlePrefab;
        [SerializeField] private ManaController manaController;
        


        public UnityEvent AttackSucceededEvent;
        public UnityEvent AttackFailedEvent;

        private void OnEnable()
        {
            inputManager.MouseLeftButtonClickedEvent += OnMouseLeftButtonClicked; 
            inputManager.MousePositionChangedEvent += OnMousePositionChanged;

        }

        private void OnDisable()
        {
            inputManager.MouseLeftButtonClickedEvent -= OnMouseLeftButtonClicked;
            inputManager.MousePositionChangedEvent -= OnMousePositionChanged;

        }

        private void OnMouseLeftButtonClicked()
        {
            //if (attackDelayReady && manaController.HaveEnoughMana())
            //{
               // attackDelayReady = false;
                //StartCoroutine(ResetAttackDelayReady());
                var worldPoint = (Vector2)camera.ScreenToWorldPoint(_mousePosition);
            
                var ab = worldPoint - (Vector2)weaponGemTransform.position;


                GameObject newBullet = Instantiate(bulletPrefab, weaponGemTransform.position, Quaternion.identity);
                newBullet.transform.right = ab.normalized;
                Instantiate(particlePrefab, weaponGemTransform.position, Quaternion.identity);
            
                AttackSucceededEvent.Invoke();
            // }
            // else
            // {
            //     AttackFailedEvent.Invoke();
            // }
        }

        // private IEnumerator ResetAttackDelayReady()
        // {
        //     yield return new WaitForSeconds(attackDelay);
        //     attackDelayReady = true;
        // }


        private void OnMousePositionChanged(Vector2 obj)
        {
            _mousePosition = obj;
        }
    }
}