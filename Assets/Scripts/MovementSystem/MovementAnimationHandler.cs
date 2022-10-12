using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Sequence = DG.Tweening.Sequence;

namespace MovementSystem
{
    public class MovementAnimationHandler : MonoBehaviour
    {
        [SerializeField] private Transform transform;
        [SerializeField] private float height;
        [SerializeField] private float duration;

        private Sequence _sequence;
        [SerializeField] private UnityEvent steppedEvent;

        public void Start()
        {
            _sequence = DOTween.Sequence().Append(transform.DOLocalMoveY( height, duration)).SetLoops(-1).OnStepComplete(
                () =>
                { 
                    steppedEvent.Invoke();
                });
            StopSequence();
        }
        [ContextMenu("Stop Sequence")]
        public void StopSequence()
        {
            _sequence.Pause();
        }
        [ContextMenu("Start Sequence")]
        public void StartSequence()
        {
            _sequence.Play();
        }
    
    
    }
}
