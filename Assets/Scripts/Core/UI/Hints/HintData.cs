using UnityEngine;
namespace Core.UI.Hint
{
    [CreateAssetMenu(fileName = "NewHint", menuName = "Hints/Hint Data")]
    public class HintData : ScriptableObject
    {
        public string hintId;  
        [TextArea] public string text;
        public float duration = 5f;
    }
}