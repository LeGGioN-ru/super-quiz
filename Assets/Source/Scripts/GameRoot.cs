using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameRoot : LifetimeScope
{
    [SerializeField] private TypesLevelSettings _typesLevelSettings;
    [SerializeField] private LevelsSettings _levelsSettings;
    [SerializeField] private Transform _centerPoint;
    [SerializeField] private CellPresenter _prefab;
    [SerializeField] private LevelRestarter _restarterPresenter;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GridGenerator>(Lifetime.Singleton).AsSelf().WithParameter(_prefab).WithParameter(_centerPoint);
        builder.Register<TypeLevelGenerator>(Lifetime.Singleton).AsSelf();
        builder.Register<LevelGenerator>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<AnswerChecker>(Lifetime.Singleton).AsSelf();
        builder.RegisterComponentInHierarchy<FindText>();
        builder.RegisterComponentInHierarchy<CoroutineStarter>();
        builder.RegisterComponentInHierarchy<LevelRestarter>();
        builder.Register<LevelsSwitcher>(Lifetime.Singleton).AsImplementedInterfaces().WithParameter(_typesLevelSettings).WithParameter(_levelsSettings).WithParameter(_restarterPresenter).AsSelf();
        builder.Register<LevelCleaner>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        builder.Register<CellAppearanceAnimator>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
    }
}
