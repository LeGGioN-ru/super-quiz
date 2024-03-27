using Level;
using Level.Generating;
using System;
using Utility;
using VContainer.Unity;

namespace Animations
{
    public class CellAppearanceAnimator : IInitializable, IDisposable
    {
        private readonly LevelGenerator _levelGenerator;
        private readonly LevelsSwitcher _levelsSwitcher;

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
                bounceAnimation.Play(i * AppConstants.BounceDuration);
            }
        }
    }
}