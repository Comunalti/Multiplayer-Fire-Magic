using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class AutoTween : MonoBehaviour
    {
        [SerializeField] private float startDuration;
        [SerializeField] private float middleDuration;
        [SerializeField] private float endDuration;

        [SerializeField] private Ease startEase;
        [SerializeField] private Ease endEase;
        private IEnumerator Start()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, startDuration).SetEase(startEase);
            yield return new WaitForSeconds(middleDuration);
            transform.DOScale(Vector3.zero, endDuration).SetEase(endEase);
        }
    }
}