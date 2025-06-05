using UnityEngine;
[CreateAssetMenu(fileName = "Prefabs", menuName = "ScriptableObjects/Prefabs", order = 4)]
public class PrefabContainer : ScriptableObject
{
    public GameObject ExpObject;
    public GameObject StatusDisplay;
    public Sprite Bleeded;
    public Sprite PrimaryAttack;
    public Sprite SecondaryAttack;
    public Sprite TertiaryAttack;
}
