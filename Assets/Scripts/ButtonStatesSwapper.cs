using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonStatesSwapper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{   
    [Header("Sprites")]
    [SerializeField] private Sprite _highlited;
    [SerializeField] private Sprite _pressed;
    [SerializeField] private Sprite _disabled;
    [SerializeField] private Sprite _selected;
    [SerializeField] private Sprite _borderEnabled;
    [SerializeField] private Sprite _borderDisabled;

    [SerializeField] private Image _border;

    private Button _button;
    private Color _white = Color.white;
    private SpriteState _state;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_button.interactable == false)
            return;

        _border.sprite = _borderEnabled;
        _border.color = Color.white;
        _white.a = 1;
        _border.color = _white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_button.interactable == false)
            return;

        _border.sprite = null;
        _white.a = 0;
        _border.color = _white;
    }

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.transition = Selectable.Transition.SpriteSwap;
        SpriteState state = new SpriteState();
        state.highlightedSprite = _highlited;
        state.disabledSprite = _disabled;
        state.pressedSprite = _pressed;
        _button.spriteState = state;
    }
}
