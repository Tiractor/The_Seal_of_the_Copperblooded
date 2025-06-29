
using Core.Events;
using System.Collections.Generic;

namespace Core.UI.Hint
{
    public class HintSystem : ComponentSystem
    {
        public HintComponent hintUI;
        public HashSet<string> shownHints = new();

        public override void Initialize()
        {
            Subscribe<HintComponent, ComponentInitEvent>(OnComponentInit);
            Subscribe<HintComponent, ShowHintEvent>(OnShowHint);
        }
        private void OnComponentInit(HintComponent component, ComponentInitEvent args)
        {
            hintUI = component;
        }
        private void OnShowHint(HintComponent component, ShowHintEvent evt)
        {
            if (shownHints.Contains(evt.data.hintId)) return;

            shownHints.Add(evt.data.hintId);
            hintUI.Show(evt.data.text, evt.data.duration);
        }
    }
}
