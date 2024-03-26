using TMPro;
using UnityEngine;
using VContainer;

public class FindText : MonoBehaviour
{
    [SerializeField] private TMP_Text _findText;

    private LevelsSwitcher _switcher;
    private FadeAnimation _fadeAnimation;
    private AnswerChecker _checker;

    [Inject]
    public void Construct(LevelsSwitcher levelSwitcher, AnswerChecker answerChecker)
    {
        _fadeAnimation = new FadeAnimation(transform);

        _checker = answerChecker;
        _switcher = levelSwitcher;

        _switcher.FirstLevelStarted += OnFirstLevelStarted;
        _switcher.NewLevelStarted += OnNewLevelStarted;
    }

    private void OnDisable()
    {
        _switcher.FirstLevelStarted -= OnFirstLevelStarted;
        _switcher.NewLevelStarted -= OnNewLevelStarted;
    }

    private void OnNewLevelStarted()
    {
        ShowText(false);
    }

    private void OnFirstLevelStarted()
    {
        ShowText(true);
    }

    private void ShowText(bool needAnimation)
    {
        if (needAnimation)
        {
            _fadeAnimation.Play(1f, 1, 0, 0);
        }

        _findText.text = "Find " + _checker.RightAnswer.Identifier;
    }
}
