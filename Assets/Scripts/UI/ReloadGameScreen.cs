using System;

public class ReloadGameScreen : Window
{
    public event Action RestartButtonClick;

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}