using System;
using UnityEngine;
using VContainer;

public class CellPresenter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _objectInCard;
    [SerializeField] private ParticleSystem _stars;

    private AnswerChecker _answerChecker;
    private AnimationTween _wrongAnswerAnimation;
    private AnimationTween _rightAnswerAnimation;
    private bool _isParticlesSpawned;

    public CellData Settings { get; private set; }

    [Inject]
    public void Construct(AnswerChecker answerChecker)
    {
        _answerChecker = answerChecker;
        _wrongAnswerAnimation = new ShakeAnimation(_objectInCard.transform);
        _rightAnswerAnimation = new BounceAnimation(_objectInCard.transform);

        _answerChecker.OnRightAnswer += OnRightAnswer;
        _answerChecker.OnWrongAnswer += OnWrongAnswer;
    }

    private void OnDisable()
    {
        _answerChecker.OnRightAnswer -= OnRightAnswer;
        _answerChecker.OnWrongAnswer -= OnWrongAnswer;
    }

    public void SetType(CellData settings)
    {
        Settings = settings;
        _objectInCard.sprite = settings.Sprite;
        _objectInCard.transform.rotation = settings.SpriteRotate;
    }

    public void OnCellClick()
    {
        _answerChecker.CheckAnswer(Settings);
    }

    private void OnRightAnswer(CellData cellData)
    {
        if (cellData != Settings)
            return;

        if (_isParticlesSpawned == false)
        {
            Instantiate(_stars, transform);
            _isParticlesSpawned = true;
        }

        _rightAnswerAnimation.Play(.125f);
    }

    private void OnWrongAnswer(CellData cellData)
    {
        if (cellData != Settings)
            return;

        _wrongAnswerAnimation.Play(0.05f);
    }

   
}
