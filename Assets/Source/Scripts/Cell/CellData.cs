using System;
using UnityEngine;

namespace Cells
{
    [Serializable]
    public class CellData
    {
        [field: SerializeField] public string Identifier { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public Quaternion SpriteRotate { get; private set; }
    }
}
