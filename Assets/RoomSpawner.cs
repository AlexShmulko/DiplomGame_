using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;

    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right,
        None
    }

    private int maxRoomsToSpawn = 20;
    private static int roomsSpawnedCount = 0;

    private RoomVariants variants;
    private GameObject roomParent;

    private int rand;
    private bool spawned = false;
    private float waitTime = 3f;

    private List<Vector3> recordedRoomPointPositions = new List<Vector3>();

    private void Start()
    {

        roomParent = GameObject.Find("Grid");

        if (roomParent == null)
        {
            Debug.LogError("Room parent object not found!");
            return;
        }

        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        //Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.1f);
    }

    public void Spawn()
    {
        if (!spawned && roomsSpawnedCount < maxRoomsToSpawn)
        {
            GameObject newRoom = null;

            switch (direction)
            {
                case Direction.Top:
                    rand = Random.Range(0, variants.topRooms.Length);
                    //newRoom = Instantiate(variants.topRooms[rand], transform.position, variants.topRooms[rand].transform.rotation);
                    newRoom = Instantiate(variants.topRooms[rand], transform.position, Quaternion.identity);
                    //newRoom = Instantiate(variants.topRooms[rand], transform.position, Quaternion.identity, roomParent.transform);
                    break;
                case Direction.Bottom:
                    rand = Random.Range(0, variants.bottomRooms.Length);
                    //newRoom = Instantiate(variants.bottomRooms[rand], transform.position, variants.bottomRooms[rand].transform.rotation);
                    newRoom = Instantiate(variants.bottomRooms[rand], transform.position, Quaternion.identity);
                    //newRoom = Instantiate(variants.bottomRooms[rand], transform.position, Quaternion.identity, roomParent.transform);
                    break;
                case Direction.Right:
                    rand = Random.Range(0, variants.rightRooms.Length);
                    //newRoom = Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
                    newRoom = Instantiate(variants.rightRooms[rand], transform.position, Quaternion.identity);
                    //newRoom = Instantiate(variants.rightRooms[rand], transform.position, /*Quaternion.identity,*/variants.rightRooms[rand].transform.rotation);
                    break;
                case Direction.Left:
                    rand = Random.Range(0, variants.leftRooms.Length);
                    //newRoom = Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
                    newRoom = Instantiate(variants.leftRooms[rand], transform.position, Quaternion.identity);
                    //newRoom = Instantiate(variants.leftRooms[rand], transform.position, /*Quaternion.identity, */variants.leftRooms[rand].transform.rotation);
                    break;
            }

            if (newRoom != null)
            {
                //newRoom.transform.SetParent(GameObject.Find("Grid").transform);
                newRoom.transform.SetParent(roomParent.transform);
                //CheckRoomPoints(newRoom);
                spawned = true;
                roomsSpawnedCount++; 
                
                // Получить все дочерние объекты с тегом "RoomPoint"
                GameObject[] roomPoints = GameObject.FindGameObjectsWithTag("RoomPoint");

                // Записать и вывести координаты каждого объекта
                foreach (GameObject roomPoint in roomPoints)
                {
                    // Получить координаты объекта
                    Vector3 objectPosition = roomPoint.transform.position;

                    // Проверить, не записаны ли уже координаты этой точки
                    if (!recordedRoomPointPositions.Contains(objectPosition) && objectPosition != Vector3.zero)
                    {
                        // Если координаты ещё не записаны, добавить их в список и вывести
                        recordedRoomPointPositions.Add(objectPosition);
                        Debug.Log("RoomPoint coordinates: " + objectPosition);
                    }
                    else
                    {
                        // Если координаты уже записаны, удалить новую точку
                        Debug.Log("RoomPoint at coordinates " + objectPosition + " already exists. Deleting...");
                        Destroy(roomPoint);
                    }
                }
            }
        }
    }

    private void CheckRoomPoints(GameObject room)
    {
        RoomSpawner[] roomSpawners = room.GetComponentsInChildren<RoomSpawner>();

        foreach (RoomSpawner spawner in roomSpawners)
        {
            if (spawner.CompareTag("RoomPoint") && spawner.direction == GetOppositeDirection(direction))
            {
                spawner.gameObject.SetActive(false);
            }
        }
    }

    private Direction GetOppositeDirection(Direction dir)
    {
        switch (dir)
        {
            case Direction.Top:
                return Direction.Bottom;
            case Direction.Bottom:
                return Direction.Top;
            case Direction.Left:
                return Direction.Right;
            case Direction.Right:
                return Direction.Left;
            default:
                return Direction.None;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("RoomPoint") && other.GetComponent<RoomSpawner>().spawned)
        {
            //Destroy(gameObject);
        }
    }
}
