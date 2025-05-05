using TMPro;
using UnityEngine;

public class ItemTooltip : MonoBehaviour
{
    public TextMeshProUGUI descriptionText;
    public RectTransform background;
    public static ItemTooltip Instance;

    private void Awake() 
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Show(string text, Vector2 position)
    {
        gameObject.SetActive(true);
        descriptionText.text = text;
        background.position = position;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
