using Core.Events;
using TMPro;
using UnityEngine;
namespace Core.Interactable
{
    public class InteractUI : EventComponent
    {
        public GameObject root;
        public TextMeshProUGUI promptText;

        public void Show(string prompt)
        {
            root.SetActive(true);
            promptText.text = prompt;
        }

        public void Hide()
        {
            root.SetActive(false);
        }
    }
}