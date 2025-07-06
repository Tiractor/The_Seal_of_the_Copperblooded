using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Switch_Button_UI : MonoBehaviour
{
    public UnityEvent m_OnPress;
    public UnityEvent m_OnUnpress;

    public string Text;

    [SerializeField] private TMP_Text s_OnPress;
    [SerializeField] private TMP_Text s_OnUnpress;

    public bool CheckPressed = false;
    private static Switch_Button_UI pressed;

    private void OnValidate()
    {
        Refresh();
    }
    public void Refresh()
    {
        if (s_OnPress != null) s_OnPress.text = Text;
        if (s_OnUnpress != null) s_OnUnpress.text = Text;
    }

    public void Press()
    {
        if (CheckPressed)
        {
            if (pressed != null) pressed.Unpress();
            pressed = this;
        }
        m_OnPress.Invoke();
    }
    public void Unpress()
    {
        if(pressed == this) pressed = null;
        m_OnUnpress.Invoke();
    }
}
