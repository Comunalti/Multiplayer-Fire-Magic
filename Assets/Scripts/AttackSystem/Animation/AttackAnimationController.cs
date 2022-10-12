using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace AttackSystem
{
    public class AttackAnimationController : MonoBehaviour
    {
        [SerializeField] private AttackController attackController;
        [SerializeField] private Transform transform;
        [SerializeField] private float height;
        [SerializeField] private float time;
        private TweenerCore<Vector3, Vector3, VectorOptions> _moveY;

        private void OnEnable()
        {
            attackController.AttackSucceededEvent.AddListener(OnAttackSucceeded);
        }
        private void OnDisable()
        {
            attackController.AttackSucceededEvent.RemoveListener(OnAttackSucceeded);
        }

        private void OnAttackSucceeded()
        {
            var position = transform.localPosition;
            position.y = 0;
            transform.localPosition = position;
            transform.DOLocalMoveY(-height, time).OnComplete(()=>{transform.localPosition = Vector3.zero;}).Play();
        }
    }
}
