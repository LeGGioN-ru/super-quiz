using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameRoot : LifetimeScope
{
    [SerializeField] private TypesLevelSettings _typesLevelSettings;
    [SerializeField] private LevelsSettings _levelsSettings;
    [SerializeField] private Transform _centerPoint;
    [SerializeField] private CellPresenter _prefab;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GridGenerator>(Lifetime.Singleton).AsSelf().WithParameter(_prefab).WithParameter(_centerPoint);
        builder.Register<TypeLevelGenerator>(Lifetime.Singleton).AsSelf();
        builder.Register<LevelGenerator>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(_typesLevelSettings).WithParameter(_levelsSettings).AsSelf();
        builder.Register<GameStateChanger>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
    }
}
