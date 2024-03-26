using UnityEngine;

public interface IScalebleStrategy
{
    public void Scale(Transform transform, float duration, float delay = 0);
}
