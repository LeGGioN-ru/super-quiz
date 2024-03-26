using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Types Settings", menuName = "Game Settings/Levels/Create Levels Types", order = 1)]
public class TypesLevelSettings : ScriptableObject
{
    [SerializeField] private List<Settings> _types;

    public IReadOnlyList<Settings> Types => _types;

    [Serializable]
    public class Settings
    {
        [SerializeField] private string _identifier;
        [SerializeField] private List<CellData> _levelCells;

        public IReadOnlyList<CellData> LevelCells => _levelCells;
    }
}
