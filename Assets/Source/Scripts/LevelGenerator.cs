using System.Collections.Generic;
using System.Linq;

public class LevelGenerator
{
    private readonly LevelsSettings _levelSettings;
    private readonly TypesLevelSettings _typesLevelSettings;
    private readonly GridGenerator _gridGenerator;
    private readonly TypeLevelGenerator _typeLevelGenerator;

    private int _currentLevelIndex;
    private CellData _rightAnswer;
    private TypesLevelSettings.Settings _currentType;

    private LevelsSettings.Settings CurrentLevel => _levelSettings.ListSettings[_currentLevelIndex];

    public LevelGenerator(LevelsSettings levelsSettings, TypesLevelSettings typesLevelSettings, GridGenerator gridGenerator, TypeLevelGenerator typeLevelGenerator)
    {
        _levelSettings = levelsSettings;
        _typesLevelSettings = typesLevelSettings;
        _gridGenerator = gridGenerator;
        _typeLevelGenerator = typeLevelGenerator;
    }

    public void GenerateNewLevel()
    {
        List<CellPresenter> objects = _gridGenerator.Generate(CurrentLevel.Columns, CurrentLevel.Rows, _levelSettings.Space);
        _currentType = _typesLevelSettings.Types.RandomElement();
        _rightAnswer = _typeLevelGenerator.Generate(objects.ToArray(), _currentType);
        BounceAnimation bounceAnimation = new BounceAnimation();

        for (int i = 0; i < objects.Count; i++)
        {
            bounceAnimation.Scale(objects[i].transform, 0.125f, i * 0.125f);
        }
    }

    public void GenerateNextLevel()
    {

    }
}
