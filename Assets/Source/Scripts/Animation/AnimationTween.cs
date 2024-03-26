using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public abstract class AnimationTween
    {
        protected Transform Target;

        public AnimationTween(Transform target)
        {
            Target = target;
        }

        public abstract Tween Play(float duration, float delay = 0);
    }
}