using System;
using UnityEngine;
namespace Core.Language
{
    [CreateAssetMenu(fileName = "Text Data", menuName = "ScriptableObjects/Text", order = 2)]
    public class TextData : ScriptableObject
    {
        [Serializable]
        public struct TextTranslator
        {
            public language Language;
            public string Text;
            public TextTranslator(language _lang, string _text)
            {
                Language = _lang;
                Text = _text;
            }

        }
        public TextTranslator[] TextTranslations;
        private TextTranslator Error = new(language.English, "Translation Error");
        public TextTranslator GetTextByLanguage(language Target)
        {
            foreach (var translator in TextTranslations) 
            { 
                if(translator.Language == Target) return translator;
            }
            return Error;
        }
    }
}