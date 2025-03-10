using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Interactable_UI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color NewColor;
    private Image imageComponent;
    private Color originalColor;
    public UnityEvent m_OnClick;
    public UnityEvent m_OnMouseEnter;
    public UnityEvent m_OnMouseExit;
    public bool ActivityInteractable = true;
    public bool EnableColorSwitch = true;

    private void Awake()
    {
        InitImageComponent();
    }

    private void InitImageComponent()
    {
        imageComponent = GetComponent<Image>();
        if (imageComponent == null)
        {
            Core.Logger.Warn("GameObject doesn't contain Image component");
            return;
        }

        originalColor = imageComponent.color; // Сохраняем текущий цвет изображения
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if (!ActivityInteractable)
            return;
        m_OnMouseEnter.Invoke();

        if (EnableColorSwitch)
            imageComponent.color = NewColor; // Изменяем цвет UI-элемента
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!ActivityInteractable)
            return;

        m_OnMouseExit.Invoke();

        if (EnableColorSwitch)
            imageComponent.color = originalColor; // Восстанавливаем исходный цвет
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!ActivityInteractable)
            return;
        m_OnClick.Invoke();
    }

    public void SetInteractable(bool check)
    {
        ActivityInteractable = check;
    }
}
