using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace HUD
{
    [RequireComponent(typeof(CanvasGroup))]
    public class HitFx : MonoBehaviour
    {
        [SerializeField] private float duration;
        [SerializeField] private int loop;
        [SerializeField] private LoopType loopType;
        [SerializeField] private Ease ease;
        private CanvasGroup _canvasGroup;
        private Sequence _seq;
        
        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0;
        }
        
        [Button("Play")]
        public void Play()
        {
            _canvasGroup.alpha = 0;
            _seq = DOTween.Sequence();
            _seq.Append(_canvasGroup.DOFade(1f, duration)).SetLoops(this.loop, this.loopType).SetEase(ease).OnComplete(() =>
            {
                _canvasGroup.DOFade(0f, duration);
            });
        }
        [Button("Stop")]
        public void Stop()
        {
            _seq?.Kill();
            _canvasGroup.alpha = 0;
        }

    }
}