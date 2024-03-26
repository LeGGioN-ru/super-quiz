using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class LevelRestarter : MonoBehaviour
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
        _buttonAnimation = new BounceAnimation(_background.transform);

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
        _coroutineStarter.StartWithDelay(2, () => Enable());
    }

    private void OnButtonPressed()
    {
        _buttonHandler.gameObject.SetActive(false);

        float duraionFade = 1f;

        Tween tween = null;

        tween = _backgroundAnimation.Fade(duraionFade, 1, _background.color.a, 0);
        tween.OnComplete(() =>
        {
            GameRestarted?.Invoke();
            Tween lastTween = _backgroundAnimation.Fade(duraionFade, 0, 1, 0);
            lastTween.OnComplete(() => Disable());
        });
    }

    private void Enable()
    {
        _buttonAnimation.Play(0.125f);
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
