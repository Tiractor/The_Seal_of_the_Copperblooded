using System.Collections.Generic;
using UnityEngine;

public class ProceduralLevelGenerator : MonoBehaviour
{
    public Rooms rooms; // Массив возможных префабов комнат
    public int roomCount = 10; // Сколько комнат нужно сгенерировать
    private List<GameObject> spawnedRooms = new List<GameObject>();

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        // Начальная комната
        GameObject startRoom = Instantiate(rooms.roomPrefabs[0].prefab, Vector3.zero, Quaternion.identity);
        spawnedRooms.Add(startRoom);
        var rmLn = rooms.roomPrefabs.Length;
        // Проходимся по количеству комнат
        for (int i = 1; i < roomCount; i++)
        {
            // Найти случайную комнату для добавления
            
            Room newRoom = rooms.roomPrefabs[Random.Range(0, rmLn)];
            bool roomPlaced = false;

            // Пробуем соединить с любой из существующих комнат
            foreach (GameObject existingRoom in spawnedRooms)
            {
                Transform[] existingPoints = existingRoom.GetComponent<Room>().entryPoints;

                foreach (Transform point in existingPoints)
                {
                    // Проверить возможность размещения новой комнаты
                    // (тут можно добавить проверку на пересечение)
                    Vector3 newPosition = point.position; // Позиция соединения
                    GameObject room = Instantiate(newRoom.prefab, newPosition, Quaternion.identity);

                    // Проверка пересечения с другими комнатами

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
