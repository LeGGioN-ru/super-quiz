using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator
{
    private readonly GridGenerator _gridGenerator;
    private readonly TypeLevelGenerator _typeLevelGenerator;
    private readonly AnswerChecker _answerChecker;

    private List<CellPresenter> _cellPresenters;
    private CellData _rightAnswer;

    public IReadOnlyList<MonoBehaviour> CellPresenters => _cellPresenters;

    public LevelGenerator(GridGenerator gridGenerator, TypeLevelGenerator typeLevelGenerator,AnswerChecker answerChecker)
    {
        _answerChecker = answerChecker;
        _gridGenerator = gridGenerator;
        _typeLevelGenerator = typeLevelGenerator;
    }

    public void GenerateNewLevel(LevelsSettings.Settings level, float space, TypesLevelSettings.Settings type)
    {
        GenerateLevel(level, space, type);
    }

    private void GenerateLevel(LevelsSettings.Settings level, float space, TypesLevelSettings.Settings type)
    {
        _cellPresenters = _gridGenerator.Generate(level.Columns, level.Rows, space);
        _rightAnswer = _typeLevelGenerator.Generate(_cellPresenters.ToArray(), type);
        _answerChecker.LoadAnswer(_rightAnswer);
    }
}
