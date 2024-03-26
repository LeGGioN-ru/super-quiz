using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class CellInstaller : LifetimeScope
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CellPresenter _cellPresenter;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<CellPresenter>(Lifetime.Transient).
    }
}
