using UnityEngine;

namespace Core.UI.Codex
{
    [CreateAssetMenu(fileName = "CodexEntry", menuName = "Codex/Entry")]
    public class CodexEntry : ScriptableObject
    {
        public string entryID;
        public string entryName;
        [TextArea] public string content;
    }
}