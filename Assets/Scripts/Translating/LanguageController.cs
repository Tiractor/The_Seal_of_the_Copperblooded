using Core.Events;
using UnityEngine;

namespace Core.Language 
{ 
    public enum language
    {
        Russian,
        English
    }
    public class LanguageController : EntitySystem
    {
        public class LanguageChangeEvent : SimpleEvent
        {
            
        }
        static language CurrentLanguage = language.Russian;
        public override void Initialize()
        {
            Subscribe<MetaTextSync, ComponentInitEvent>(OnComponentInit);
            Subscribe<MetaTextSync, ComponentInitEvent>(OnComponentInit);
        }

        private void OnComponentInit(MetaTextSync component, ComponentInitEvent args)
        {
            component.WhereText.text = component.WhatText.GetTextByLanguage(CurrentLanguage).Text;
        }
    }
}
