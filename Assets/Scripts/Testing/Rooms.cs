using UnityEngine;

[CreateAssetMenu(fileName = "Room", menuName = "ScriptableObjects/Room", order = 1)]
public class Rooms : ScriptableObject
{
    public Room[] roomPrefabs;
}
