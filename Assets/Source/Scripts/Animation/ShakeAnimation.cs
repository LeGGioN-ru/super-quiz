using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public class ShakeAnimation : AnimationTween
    {
        private Vector3 _originalPosition;

        public ShakeAnimation(Transform target) : base(target)
        {
            _originalPosition = target.position;
        }

        public override Tween Play(float duration, float delay = 0)
        {
            return Shake(duration, delay);
        }

        public Tween Shake(float duration, float delay)
        {
            Sequence mySequence = DOTween.Sequence().SetDelay(delay);

            mySequence.Append(Target.DOMoveX(_originalPosition.x - 0.1f, duration).SetEase(Ease.InBounce));
            mySequence.Append(Target.DOMoveX(_originalPosition.x + 0.1f, duration).SetEase(Ease.InBounce));
            mySequence.Append(Target.DOMoveX(_originalPosition.x - 0.1f, duration).SetEase(Ease.InBounce));
            mySequence.Append(Target.DOMoveX(_originalPosition.x, duration).SetEase(Ease.InBounce));

            return mySequence.Play();
        }
    }
}