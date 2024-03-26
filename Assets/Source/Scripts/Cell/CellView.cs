using UnityEngine;
using VContainer;

public class CellView : MonoBehaviour
{
    private CellPresenter _cellPresenter;

    [Inject]
    public void Construct(CellPresenter cellPresenter)
    {
        _cellPresenter = cellPresenter;
    }

    private void OnMouseDown()
    {
        _cellPresenter.OnCellClick();
    }
}
