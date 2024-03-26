using System;
using UnityEngine;
using VContainer.Unity;

public class CellAppearanceAnimator : IInitializable, IDisposable
{
    private readonly LevelGenerator _levelGenerator;
    private readonly LevelsSwitcher _levelsSwitcher;

    private const float _appearanceDelay = 0.125f;

    public CellAppearanceAnimator(LevelGenerator levelGenerator, LevelsSwitcher levelsSwitcher)
    {
        _levelGenerator = levelGenerator;
        _levelsSwitcher = levelsSwitcher;
    }

    public void Initialize()
    {
        _levelsSwitcher.FirstLevelStarted += Animate;
    }

    public void Dispose()
    {
        _levelsSwitcher.FirstLevelStarted -= Animate;
    }

    private void Animate()
    {
        for (int i = 0; i < _levelGenerator.CellPresenters.Count; i++)
        {
            BounceAnimation bounceAnimation = new BounceAnimation(_levelGenerator.CellPresenters[i].transform);
            bounceAnimation.Play(i * _appearanceDelay);
        }
    }
}
