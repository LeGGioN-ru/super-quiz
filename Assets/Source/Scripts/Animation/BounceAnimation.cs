using DG.Tweening;
using UnityEngine;

public class BounceAnimation : IScalebleStrategy
{
    private Vector3 _startScale;

    public void Scale(Transform transform, float duration, float delay = 0)
    {
        Bounce(transform, duration, duration, duration, delay);
    }

    public void Scale(Transform transform, float duration, float duration2, float duration3, float delay = 0)
    {
        Bounce(transform, duration, duration2, duration3, delay);
    }

    private void Bounce(Transform transform, float duration, float duration2, float duration3, float delay)
    {
        transform.DOKill();
        Sequence mySequence = DOTween.Sequence().SetDelay(delay);
        _startScale = transform.localScale;
        transform.localScale = Vector3.zero;
        mySequence.Append(transform.DOScale(_startScale + new Vector3(.3f, .3f, .3f), duration))
                  .Append(transform.DOScale(_startScale - new Vector3(.2f, .2f, .2f), duration2))
                  .Append(transform.DOScale(_startScale, duration3));
    }
}
