using System.Collections.Generic;
using System.Linq;

public class TypeLevelGenerator
{
    private readonly List<string> _usedIdentifiers = new List<string>();

    public CellData Generate(CellPresenter[] cells, TypesLevelSettings.Settings type)
    {
        return SetGetRandomTypes(cells, type);
    }

    private CellData SetGetRandomTypes(CellPresenter[] cells, TypesLevelSettings.Settings type)
    {
        List<CellData> usedInGrid = new List<CellData>();
        int randomRightAnswerIndex = UnityEngine.Random.Range(0, cells.Length);
        CellData rightAnswer = GetRandomRightAnswer(type);
        CellData answer;

        for (int i = 0; i < cells.Length; i++)
        {
            if (i != randomRightAnswerIndex)
            {
                answer = type.LevelCells.RandomElement();

                if ((usedInGrid.Contains(answer) && usedInGrid.Count < type.LevelCells.Count) || answer.Identifier == rightAnswer.Identifier)
                {
                    i--;
                    continue;
                }
            }
            else
            {
                answer = rightAnswer;
            }

            usedInGrid.Add(answer);
            cells[i].SetType(answer);
        }

        return rightAnswer;
    }

    private CellData GetRandomRightAnswer(TypesLevelSettings.Settings type)
    {
        if (GetNotUsedTypes(type).Count == 0)
            _usedIdentifiers.Clear();

        List<CellData> notUsed = GetNotUsedTypes(type);

        CellData rightAnswer = notUsed.RandomElement();
        _usedIdentifiers.Add(rightAnswer.Identifier);
        return rightAnswer;
    }

    private List<CellData> GetNotUsedTypes(TypesLevelSettings.Settings type)
    {
        return type.LevelCells.Where(x => _usedIdentifiers.Contains(x.Identifier) == false).ToList();
    }
}
