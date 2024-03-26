using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animations
{
    public class FadeAnimation : AnimationTween 
    {
        private readonly TMP_Text _textTarget;
        private readonly Image _image;

        public FadeAnimation(Transform target) : base(target)
        {
            Image image = target.GetComponent<Image>();

            if (image != null)
                _image = image;

            TMP_Text text = target.GetComponent<TMP_Text>();

            if (text != null)
                _textTarget = text;

            if (_textTarget == null && _image == null)
                throw new System.Exception();
        }

        public Tween Fade(float duration, float endValue, float startAlpha, float delay)
        {
            Color startColor = Color.white;

            if (_textTarget != null)
            {
                startColor = SetStartColor(_textTarget.color, startAlpha);
                _textTarget.color = startColor;
                return _textTarget.DOFade(endValue, duration).SetDelay(delay);
            }
            else if (_image != null)
            {
                startColor = SetStartColor(_image.color, startAlpha);
                _image.color = startColor;
                return _image.DOFade(endValue, duration).SetDelay(delay);
            }

            throw new System.Exception("не удалось запустить анимацию!");
        }

        public override Tween Play(float duration, float delay = 0)
        {
            return Fade(duration, 1, 0, delay);
        }

        public Tween Play(float duration, float target, float start, float delay = 0)
        {
            return Fade(duration, target, start, delay);
        }

        private Color SetStartColor(Color color, float startAlpha)
        {
            return new Color(color.r, color.g, color.b, startAlpha);
        }
    }
}