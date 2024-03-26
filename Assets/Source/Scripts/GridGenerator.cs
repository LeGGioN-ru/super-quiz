using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GridGenerator
{
    private readonly Transform _centerPoint;
    private readonly CellPresenter _prefab;

    public GridGenerator(Transform centerPoint, CellPresenter prefab)
    {
        _centerPoint = centerPoint;
        _prefab = prefab;
    }

    public List<CellPresenter> Generate(int columns, int rows, float space)
    {
        List<CellPresenter> list = new List<CellPresenter>();
        Vector3 offset = new Vector3((columns - 1) * space / 2, (rows - 1) * space / 2, 0);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = new Vector3(_centerPoint.position.x + j * space - offset.x, _centerPoint.position.y + i * space - offset.y, _centerPoint.position.z);

                CellPresenter obj = GameObject.Instantiate(_prefab, position, Quaternion.identity);

                list.Add(obj);
            }
        }

        return list;
    }
}
