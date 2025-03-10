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

    private void OnValidate()
    {
        if (s_OnPress != null) s_OnPress.text = Text;
        if(s_OnUnpress != null) s_OnUnpress.text = Text;
    }

    public void Press()
    {
        m_OnPress.Invoke();
    }
    public void Unpress()
    {
        m_OnUnpress.Invoke();
    }
}
