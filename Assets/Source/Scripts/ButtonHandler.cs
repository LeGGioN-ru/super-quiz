using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    public Action ButtonPressed;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        ButtonPressed?.Invoke();
    }
}
