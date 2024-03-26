using DG.Tweening;
using UnityEngine;

public class BounceAnimation : AnimationTween
{
    private Vector3 _startScale;

    public BounceAnimation(Transform target) : base(target)
    {
        _startScale = target.localScale;
    }

    public override Tween Play(float duration, float delay = 0)
    {
      return Bounce(Target, duration, delay);
    }

    private Tween Bounce(Transform transform, float duration, float delay)
    {
        Sequence sequence = DOTween.Sequence().SetDelay(delay);
        transform.localScale = Vector3.zero;
        return sequence.Append(transform.DOScale(_startScale + new Vector3(.3f, .3f, .3f), duration))
                    .Append(transform.DOScale(_startScale - new Vector3(.2f, .2f, .2f), duration))
                    .Append(transform.DOScale(_startScale, duration));
    }
}
