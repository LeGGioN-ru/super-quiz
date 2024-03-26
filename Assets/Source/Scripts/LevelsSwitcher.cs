using System;
using UnityEngine;
using VContainer.Unity;

public class LevelsSwitcher : IPostInitializable, IDisposable
{
    public Action LevelsEnded;
    public Action FirstLevelStarting;
    public Action FirstLevelStarted;
    public Action NewLevelStarted;
    public Action NewLevelGenerating;
    public Action LevelLoaded;

    private readonly LevelGenerator _levelGenerator;
    private readonly AnswerChecker _checker;
    private readonly LevelsSettings _levelSettings;
    private readonly TypesLevelSettings _typesLevelSettings;
    private readonly CoroutineStarter _coroutineStarter;
    private readonly LevelRestarter _levelRestarterPresenter;

    private int _currentLevelIndex = 0;
    private const float _nextLevelDelay = 2;

    public LevelsSwitcher(LevelGenerator levelGenerator, AnswerChecker answerChecker,
        LevelsSettings levelsSettings, TypesLevelSettings typesLevelSettings, CoroutineStarter coroutineStarter,
        LevelRestarter levelRestarterPresenter)
    {
        _coroutineStarter = coroutineStarter;
        _levelSettings = levelsSettings;
        _typesLevelSettings = typesLevelSettings;
        _checker = answerChecker;
        _levelGenerator = levelGenerator;
        _levelRestarterPresenter = levelRestarterPresenter;
    }

    public void PostInitialize()
    {
        EnableNewLevel();
        _checker.OnRightAnswer += EnableNextLevel;
        _levelRestarterPresenter.GameRestarted += EnableNewLevel;
    }

    public void Dispose()
    {
        _checker.OnRightAnswer -= EnableNextLevel;
        _levelRestarterPresenter.GameRestarted -= EnableNewLevel;
    }

    private void EnableNewLevel()
    {
        _currentLevelIndex = 0;
        FirstLevelStarting?.Invoke();
        GenerateLevel();
        FirstLevelStarted?.Invoke();
    }

    private void EnableNextLevel(CellData data)
    {
        _currentLevelIndex++;

        if (_currentLevelIndex >= _levelSettings.ListSettings.Count)
        {
            LevelsEnded?.Invoke();
            return;
        }

        _coroutineStarter.StartWithDelay(_nextLevelDelay, () =>
        {
            NewLevelGenerating?.Invoke();
            GenerateLevel();
            NewLevelStarted?.Invoke();
        });
    }

    private void GenerateLevel()
    {
        _levelGenerator.GenerateNewLevel(_levelSettings.ListSettings[_currentLevelIndex],
        _levelSettings.Space, _typesLevelSettings.Types.RandomElement());
        LevelLoaded?.Invoke();
    }
}
