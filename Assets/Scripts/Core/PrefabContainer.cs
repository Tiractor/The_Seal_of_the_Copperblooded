using UnityEngine;
using Core.Roleplay.Inventory;
[CreateAssetMenu(fileName = "Prefabs", menuName = "ScriptableObjects/Prefabs", order = 4)]
public class PrefabContainer : ScriptableObject
{
    public GameObject ExpObject;
    public GameObject StatusDisplay;
    public GameObject FansyButton;
    public GameObject EntryButton;
    public Sprite Bleeded;
    public Sprite Poisoned;
    public Sprite PrimaryAttack;
    public Sprite SecondaryAttack;
    public Sprite TertiaryAttack;
    public SlotData ItemNull;
}
