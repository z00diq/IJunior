using UnityEngine;

public class InputRegistrator:IUpdatable
{
    private const KeyCode JumpKey = KeyCode.Space;

    private bool _isButtonPressed;

    public bool IsButtonPressed => _isButtonPressed;

    public void Update()
    {
        if (Input.GetKeyDown(JumpKey))
            _isButtonPressed = true;
    }

    public void ResetInput()
    {
        _isButtonPressed = false;
    }
}
