using System;
using System.Linq;
using VContainer.Unity;

public class LevelCleaner : IInitializable, IDisposable
{
    private readonly LevelsSwitcher _levelsSwitcher;
    private readonly LevelGenerator _levelGenerator;

    public LevelCleaner(LevelGenerator levelGenerator, LevelsSwitcher levelsSwitcher)
    {
        _levelGenerator = levelGenerator;
        _levelsSwitcher = levelsSwitcher;
    }
    public void Initialize()
    {
        _levelsSwitcher.NewLevelGenerating += Clear;
        _levelsSwitcher.FirstLevelStarting += Clear;
    }

    public void Dispose()
    {
        _levelsSwitcher.FirstLevelStarting -= Clear;
        _levelsSwitcher.NewLevelGenerating -= Clear;
    }

    private void Clear()
    {
        if (_levelGenerator.CellPresenters != null && _levelGenerator.CellPresenters.Count > 0)
        {
            Destroyer.Destroy(_levelGenerator.CellPresenters.Select(x => x.gameObject).ToArray());
        }
    }
}
