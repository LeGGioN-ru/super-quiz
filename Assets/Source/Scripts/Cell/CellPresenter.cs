using UnityEngine;
using VContainer;

public class CellPresenter : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public CellData Settings { get; private set; }

    [Inject]
    public void Construct(SpriteRenderer spriteRenderer)
    {
        _spriteRenderer = spriteRenderer;
    }

    public void SetType(CellData settings)
    {
        Settings = settings;
        _spriteRenderer.sprite = settings.Sprite;
        _spriteRenderer.transform.rotation = settings.SpriteRotate;
    }

    public void OnCellClick()
    {
        Debug.LogWarning("cell clicked");
    }
}
