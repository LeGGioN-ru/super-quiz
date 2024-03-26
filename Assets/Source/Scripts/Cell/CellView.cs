using Level;
using UnityEngine;
using VContainer;

namespace Cells
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private CellPresenter _cellPresenter;

        private LevelsSwitcher _levelsSwitcher;
        private bool _canClicking = true;

        [Inject]
        public void Construct(LevelsSwitcher levelsSwitcher)
        {
            _levelsSwitcher = levelsSwitcher;
            _levelsSwitcher.LevelsEnded += DisableClicking;
        }

        private void OnDisable()
        {
            _levelsSwitcher.LevelsEnded -= DisableClicking;
        }

        private void OnMouseDown()
        {
            if (_canClicking)
                _cellPresenter.OnCellClick();
        }

        private void DisableClicking()
        {
            _canClicking = false;
        }
    }
}

