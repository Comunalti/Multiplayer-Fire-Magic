using DG.Tweening;
using ManaSystem;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraController : MonoBehaviour
    {
        public Camera camera;
        public ManaController manaController;
        
        [SerializeField] private float duration;
        [SerializeField] private float strength;
        [SerializeField] private int vibrato;
        [SerializeField] private float randomness;
        
        private Tweener _tweener;

        private void OnEnable()
        {
            manaController.manaEventHandler.reachCriticEvent.AddListener(OnReachCritic);
            manaController.manaEventHandler.leaveCriticEvent.AddListener(OnLeaveCriticEvent);
        }
        
        private void OnDisable()
        {
            manaController.manaEventHandler.reachCriticEvent.RemoveListener(OnReachCritic);
            manaController.manaEventHandler.leaveCriticEvent.RemoveListener(OnLeaveCriticEvent);
        }
        
        private void Start()
        {
            _tweener = camera.DOShakePosition(duration, strength, vibrato, randomness, false, ShakeRandomnessMode.Harmonic).SetLoops(-1).Pause();
        }
        
        private void OnLeaveCriticEvent()
        {
            _tweener.Pause();
            transform.position = new Vector3(0, 0, -10);
        }

        private void OnReachCritic()
        {
            _tweener.Play();
        }
    }
}