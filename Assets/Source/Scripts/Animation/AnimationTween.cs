using DG.Tweening;
using UnityEngine;

public abstract class AnimationTween
{
    protected Transform Target;

    public AnimationTween(Transform target)
    {
        Target = target;
    }

    public abstract Tween Play(float duration, float delay = 0);
}
