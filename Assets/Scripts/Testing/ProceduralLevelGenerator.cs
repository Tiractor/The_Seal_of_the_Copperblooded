using System.Collections.Generic;
using UnityEngine;

public class ProceduralLevelGenerator : MonoBehaviour
{
    public Rooms rooms; // ������ ��������� �������� ������
    public int roomCount = 10; // ������� ������ ����� �������������
    private List<GameObject> spawnedRooms = new List<GameObject>();

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        // ��������� �������
        GameObject startRoom = Instantiate(rooms.roomPrefabs[0].prefab, Vector3.zero, Quaternion.identity);
        spawnedRooms.Add(startRoom);
        var rmLn = rooms.roomPrefabs.Length;
        // ���������� �� ���������� ������
        for (int i = 1; i < roomCount; i++)
        {
            // ����� ��������� ������� ��� ����������
            
            Room newRoom = rooms.roomPrefabs[Random.Range(0, rmLn)];
            bool roomPlaced = false;

            // ������� ��������� � ����� �� ������������ ������
            foreach (GameObject existingRoom in spawnedRooms)
            {
                Transform[] existingPoints = existingRoom.GetComponent<Room>().entryPoints;

                foreach (Transform point in existingPoints)
                {
                    // ��������� ����������� ���������� ����� �������
                    // (��� ����� �������� �������� �� �����������)
                    Vector3 newPosition = point.position; // ������� ����������
                    GameObject room = Instantiate(newRoom.prefab, newPosition, Quaternion.identity);

                    // �������� ����������� � ������� ���������

                    spawnedRooms.Add(room);
                    roomPlaced = true;
                    break;
                }

                if (roomPlaced)
                    break;
            }
        }
    }
}
