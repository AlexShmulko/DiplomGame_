using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;

    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right,
        TopB,
        BottomB,
        LeftB,
        RightB,
        None
    }

    public float raycastDistanceX = 40f;
    public float raycastDistanceY = 10f;

    private static int roomsSpawnedCount = 0;

    private int smallRoomsCounter = 0;
    private int smallRoomsMax = 6;

    private int RoomsCounter_40x20 = 0;
    private int RoomsMax_40x20 = 1;

    private int maxRoomsToSpawn = 7;

    private RoomVariants variants;
    private RoomVariantsBig variantsBig;
    private GameObject roomParent;

    private GameObject nowRoom;
    //private Transform nowRoomTransform;

    private int rand;
    private bool spawned = false;
    private float waitTime = 3f;

    private List<Vector3> recordedRoomPointPositions = new List<Vector3>();

    private void Start()
    {
        //maxRoomsToSpawn = smallRoomsMax + RoomsMax_40x20;

        roomParent = GameObject.Find("Grid");

        nowRoom = GameObject.FindGameObjectWithTag("NowRoom");

        if (nowRoom != null) 
        {
            //nowRoomTransform = nowRoom.transform;
        }

        if (roomParent == null)
        {
            Debug.LogError("Room parent object not found!");
            return;
        }

        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        variantsBig = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariantsBig>();
        //Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.1f);
    }

    public void Spawn()
    {
        string spawnPointTag = gameObject.tag;
        Debug.Log(gameObject.tag + gameObject.name);

        RayCastFind();
        if (!spawned && roomsSpawnedCount < maxRoomsToSpawn)
        {
            GameObject newRoom = null;

            if (spawnPointTag == "RoomPoint" && smallRoomsCounter < 6)
            {   
                smallRoomsCounter ++;
                Debug.Log("SmallCount");
                newRoom = SpawnRegularRoom();
            }
            else
            {
                gameObject.SetActive(false);
            }
            
            if (spawnPointTag == "RoomPoint_40x20" && RoomsCounter_40x20 < 1)
            {
                RoomsCounter_40x20 ++;
                newRoom = SpawnSpecialRoom();
            }
            else
            {
                gameObject.SetActive(false);
            }

            if (newRoom != null)
            {
                newRoom.transform.SetParent(roomParent.transform);
                CheckRoomPoints(newRoom);
                spawned = true;
                RecordRoomPointCoordinates();
                roomsSpawnedCount++; 
            }
        }
    }

private GameObject SpawnRegularRoom()
{   
    GameObject newRoomCopy = null;

    switch (direction)
    {
        case Direction.Top:
            rand = Random.Range(0, variants.topRooms.Length);
            newRoomCopy = Instantiate(variants.topRooms[rand], transform.position, Quaternion.identity);
            RemoveNewSpawnPoints(direction);
            break;
        case Direction.Bottom:
            rand = Random.Range(0, variants.bottomRooms.Length);
            newRoomCopy = Instantiate(variants.bottomRooms[rand], transform.position, Quaternion.identity);
            RemoveNewSpawnPoints(direction);
            break;
        case Direction.Right:
            rand = Random.Range(0, variants.rightRooms.Length);
            newRoomCopy = Instantiate(variants.rightRooms[rand], transform.position, Quaternion.identity);
            RemoveNewSpawnPoints(direction);
            break;
        case Direction.Left:
            rand = Random.Range(0, variants.leftRooms.Length);
            newRoomCopy = Instantiate(variants.leftRooms[rand], transform.position, Quaternion.identity);
            RemoveNewSpawnPoints(direction);
            break;
    }

    RemoveNewSpawnPoints(direction);
    return newRoomCopy;
}

private GameObject SpawnSpecialRoom()
{   
    Debug.Log("asdasdad");

    GameObject newRoomCopy1 = null;

    switch (direction)
    {
        case Direction.TopB:
            rand = Random.Range(0, variantsBig.topRoomsB.Length);
            newRoomCopy1 = Instantiate(variantsBig.topRoomsB[rand], transform.position, Quaternion.identity);
            RemoveOldSpawnPoints(direction);
            break;
        case Direction.BottomB:
            rand = Random.Range(0, variantsBig.bottomRoomsB.Length);
            newRoomCopy1 = Instantiate(variantsBig.bottomRoomsB[rand], transform.position, Quaternion.identity);
            RemoveOldSpawnPoints(direction);
            break;
        case Direction.RightB:
            rand = Random.Range(0, variantsBig.rightRoomsB.Length);
            newRoomCopy1 = Instantiate(variantsBig.rightRoomsB[rand], transform.position, Quaternion.identity);
            RemoveOldSpawnPoints(direction);
            break;
        case Direction.LeftB:
            rand = Random.Range(0, variantsBig.leftRoomsB.Length);
            newRoomCopy1 = Instantiate(variantsBig.leftRoomsB[rand], transform.position, Quaternion.identity);
            RemoveOldSpawnPoints(direction);
            break;
    }

    RemoveOldSpawnPoints(direction);
    return newRoomCopy1;
}

private void RemoveOldSpawnPoints(Direction dir)
{
    Transform nowRoomTransform = nowRoom.transform;

    if (nowRoomTransform == null) return;

    GameObject[] oldSpawnPoints = nowRoomTransform.GetComponentsInChildren<Transform>().Where(child => child.CompareTag("RoomPoint")).Select(child => child.gameObject).ToArray();
    
    //GameObject[] oldSpawnPoints = nowRoomTransform.FindGameObjectsWithTag("RoomPoint");

    RoomSpawner.Direction roomDirection;

    foreach (GameObject roomPointObject in oldSpawnPoints)
    {
        RoomSpawner roomSpawner = roomPointObject.GetComponent<RoomSpawner>();

        if (roomSpawner != null)
        {
            roomDirection = roomSpawner.direction;

            if (roomDirection == dir)
            {
                Destroy(roomPointObject);
                Debug.Log("yes");
            }
        }

    }
}

private void RemoveNewSpawnPoints(Direction dir)
{
    Transform nowRoomTransform = nowRoom.transform;

    if (nowRoomTransform == null) return;

    GameObject[] oldSpawnPoints = nowRoomTransform.GetComponentsInChildren<Transform>().Where(child => child.CompareTag("RoomPoint_40x20")).Select(child => child.gameObject).ToArray();

    //GameObject[] oldSpawnPoints = nowRoomTransform.FindGameObjectsWithTag("RoomPoint_40x20");

    RoomSpawner.Direction roomDirection;

    foreach (GameObject roomPointObject in oldSpawnPoints)
    {
        RoomSpawner roomSpawner = roomPointObject.GetComponent<RoomSpawner>();

        if (roomSpawner != null)
        {
            roomDirection = roomSpawner.direction;

            if (roomDirection == dir)
            {
                Destroy(roomPointObject);
                Debug.Log("no");
            }
        }

    }
}

private void RayCastFind()
{   
    Vector2 leftOrigin = gameObject.transform.position;
    Vector2 rightOrigin = gameObject.transform.position;
    Vector2 upOrigin = gameObject.transform.position;
    Vector2 downOrigin = gameObject.transform.position;

    Vector2 leftDirection = -gameObject.transform.right;
    Vector2 rightDirection = gameObject.transform.right;
    Vector2 upDirection = gameObject.transform.up;
    Vector2 downDirection = -gameObject.transform.up;

    RaycastHit2D leftHit = Physics2D.Raycast(leftOrigin, leftDirection, raycastDistanceX);
    if (leftHit.collider != null)
    {
        if (leftHit.collider.CompareTag("RoomPoint") || leftHit.collider.CompareTag("RoomPoint_40x20") || leftHit.collider.CompareTag("CheckPoint") || leftHit.collider.CompareTag("Block"))
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }

    RaycastHit2D rightHit = Physics2D.Raycast(rightOrigin, rightDirection, raycastDistanceX);
    if (rightHit.collider != null)
    {   
        if (rightHit.collider.CompareTag("RoomPoint") || rightHit.collider.CompareTag("RoomPoint_40x20") || rightHit.collider.CompareTag("CheckPoint") || rightHit.collider.CompareTag("Block"))
        {   
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }

    RaycastHit2D upHit = Physics2D.Raycast(upOrigin, upDirection, raycastDistanceY);
    if (upHit.collider != null)
    {
        if (upHit.collider.CompareTag("CheckPoint") || upHit.collider.CompareTag("Block"))
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }

    RaycastHit2D downHit = Physics2D.Raycast(downOrigin, downDirection, raycastDistanceY);
    if (downHit.collider != null)
    {
        if (downHit.collider.CompareTag("CheckPoint") || downHit.collider.CompareTag("Block"))
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
    }
}

private void RecordRoomPointCoordinates()
{
    // Получить все дочерние объекты с тегом "RoomPoint"
    GameObject[] roomPoints = GameObject.FindGameObjectsWithTag("RoomPoint");

    // Записать и вывести координаты каждого объекта
    foreach (GameObject roomPoint in roomPoints)
    {
        // Получить координаты объекта
        Vector3 objectPosition = roomPoint.transform.position;

        // Проверить, не записаны ли уже координаты этой точки и что они не равны (0, 0, 0)
        if (!recordedRoomPointPositions.Contains(objectPosition) && objectPosition != Vector3.zero)
        {
            // Если координаты ещё не записаны и не равны (0, 0, 0), добавить их в список и вывести
            recordedRoomPointPositions.Add(objectPosition);
        }
        else
        {
            // Если координаты уже записаны или равны (0, 0, 0), удалить новую точку
            Destroy(roomPoint);
        }
    }
}

    private void CheckRoomPoints(GameObject room)
    {
        RoomSpawner[] roomSpawners = room.GetComponentsInChildren<RoomSpawner>();

        foreach (RoomSpawner spawner in roomSpawners)
        {
            if (spawner.CompareTag("RoomPoint") /*|| spawner.CompareTag("RoomPoint_40x20")*/ && spawner.direction == GetOppositeDirection(direction))
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
            Destroy(gameObject);
        }
    }
}
