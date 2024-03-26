using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class GameStateChanger :IInitializable
{
    private LevelGenerator _levelGenerator;

    public GameStateChanger(LevelGenerator levelGenerator)
    {
        _levelGenerator = levelGenerator;
    }

    public void Initialize()
    {
        _levelGenerator.GenerateNewLevel();
    }
}
