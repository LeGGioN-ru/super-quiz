using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Settings
{
    [CreateAssetMenu(fileName = "Levels Settings", menuName = "Game Settings/Levels/Create Level Settings", order = 1)]
    public class LevelsSettings : ScriptableObject
    {
        [SerializeField] private List<Settings> _levels;
        [field: SerializeField] public float Space { get; private set; }

        public IReadOnlyList<Settings> ListSettings => _levels;

        [Serializable]
        public class Settings
        {
            [field: SerializeField] public int Rows { get; private set; }
            [field: SerializeField] public int Columns { get; private set; }
        }
    }
}