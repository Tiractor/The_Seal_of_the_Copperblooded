using Core.Events;
using TMPro;

namespace Core.UI.Hint
{
    public class HintComponent : EventComponent
    {
        public TextMeshProUGUI text;
        private float hideTimer;

        public void Show(string msg, float duration = 5f)
        {
            gameObject.SetActive(true);
            text.text = msg;
            hideTimer = duration;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            text.text = "";
        }
    }
}
