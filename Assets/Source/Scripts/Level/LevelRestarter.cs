using Animations;
using DG.Tweening;
using System;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using VContainer;

namespace Level
{
    public class LevelRestarter : MonoBehaviour //Не успевал декомпозировать
    {
        [SerializeField] private ButtonHandler _buttonHandler;
        [SerializeField] private Image _background;

        public Action GameRestarted;

        private FadeAnimation _backgroundAnimation;
        private AnimationTween _buttonAnimation;
        private CoroutineStarter _coroutineStarter;
        private LevelsSwitcher _levelSwitcher;

        [Inject]
        public void Construct(CoroutineStarter coroutineStarter, LevelsSwitcher levelsSwitcher)
        {
            _coroutineStarter = coroutineStarter;
            _levelSwitcher = levelsSwitcher;
            _backgroundAnimation = new FadeAnimation(_background.transform);
            _buttonAnimation = new BounceAnimation(_buttonHandler.transform);

            _levelSwitcher.LevelsEnded += OnLevelsEnd;
            _buttonHandler.ButtonPressed += OnButtonPressed;
        }

        private void OnDestroy()
        {
            _levelSwitcher.LevelsEnded -= OnLevelsEnd;
            _buttonHandler.ButtonPressed -= OnButtonPressed;
        }

        private void OnLevelsEnd()
        {
            _coroutineStarter.StartWithDelay(AppConstants.LevelSwitchDuration, () => Enable());
        }

        private void OnButtonPressed()
        {
            _buttonHandler.gameObject.SetActive(false);

            float durationFade = 1f;

            Tween tween = null;

            tween = _backgroundAnimation.Fade(durationFade, 1, _background.color.a, 0);
            tween.OnComplete(() =>
            {
                GameRestarted?.Invoke();
                Tween lastTween = _backgroundAnimation.Fade(durationFade, 0, 1, 0);
                lastTween.OnComplete(() => Disable());
            });
        }

        private void Enable()
        {
            _buttonAnimation.Play(AppConstants.BounceDuration);
            _backgroundAnimation.Play(1f, 0.5f, 0, 0);
            SwitchUI(true);
        }

        private void Disable()
        {
            SwitchUI(false);
        }

        private void SwitchUI(bool state)
        {
            _buttonHandler.gameObject.SetActive(state);
            gameObject.SetActive(state);
        }
    }
}