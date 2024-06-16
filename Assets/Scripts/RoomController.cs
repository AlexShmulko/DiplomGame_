    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    private SpawnController spawnController;

    private MiniBossSpawnController minibossRoomController;

    private Transform[] childObjects;

    public GameObject newObjectPrefab;

    public GameObject newObjectBossPrefab;

    private int randomNumber;

    private int a;

    DataManager dataManager;

    public int wallCount;

    private bool miniboss;

    private int minibossRand;

    private int wallCountFmB;
    
    private int randomIndexGug;

    private int roomScore = 0;

    void Start()
    {
        dataManager = DataManager.Instance;

        StartCoroutine(StartAfterDelay(0.2f));
    }

    IEnumerator StartAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        childObjects = GetComponentsInChildren<Transform>();

        List<Transform> availableMiniBoss = new List<Transform>();

        wallCount = dataManager.GetWallCount();

        roomScore = dataManager.GetRoomScore();

        wallCountFmB = dataManager.GetWallCount();

        miniboss = dataManager.GetIsMiniBossRoomSpawned();

        if (wallCountFmB > 20 + roomScore)
        { 
            miniboss = false;
        }

        if (miniboss == false)
        {
            //minibossRand = Random.Range(1, 3);

            if ((wallCountFmB > (20 + roomScore) && wallCountFmB < (30 + roomScore)) /*|| wallCountFmB > (31 + roomScore)*/)
            {   
                foreach (Transform child in childObjects)
                {
                    if (child != null && child.CompareTag("Wall"))
                    {
                        spawnController = child.GetComponent<SpawnController>();

                        if (spawnController != null && spawnController.backroom == 0 && (spawnController.direction == SpawnController.Direction.SmallRight || spawnController.direction == SpawnController.Direction.SmallLeft))
                        {
                            availableMiniBoss.Add(child);
                        }
                    }
                }

                miniboss = true;

                dataManager.SetIsMiniBossRoomSpawned(miniboss);

                randomIndexGug = Random.Range(0, availableMiniBoss.Count);

                Transform randomWall = availableMiniBoss[randomIndexGug];    

                ReplaceBossDoor(randomWall);

                availableMiniBoss.Clear();

                roomScore += 20;
                dataManager.SetRoomScore(roomScore);
            }
        }

        Invoke("DoorCleaner", 1f);

        Invoke("DoorCounter", 2f);
    }

    void ReplaceChildren(Transform child)
    {
        Transform parent = child.parent;

        Vector3 position = child.position;
        Quaternion rotation = child.rotation;

        GameObject newObject = Instantiate(newObjectPrefab, position, rotation);

        newObject.transform.parent = parent;
        
        Destroy(child.gameObject);
    }

    void ReplaceBossDoor(Transform child)
    {
        Transform parent = child.parent;

        Vector3 position = child.position;
        Quaternion rotation = child.rotation;

        GameObject newObject = Instantiate(newObjectBossPrefab, position, rotation);

        spawnController = child.GetComponent<SpawnController>();

        minibossRoomController = newObject.GetComponent<MiniBossSpawnController>();

        if (spawnController.direction == SpawnController.Direction.SmallRight)
        {
            minibossRoomController.MB_direction = MiniBossSpawnController.MiniBossDirection.Right;
        }

        newObject.transform.parent = parent;
        
        Destroy(child.gameObject);
    }

    void DoorCleaner()
    {
        List<Transform> availableWalls = new List<Transform>();

        if (gameObject.tag == "Room_20x10")
        {
            randomNumber = Random.Range(1, 3);

            List<int> chosenIndices = new List<int>();

            a = 0;

            foreach (Transform child in childObjects)
            {
                if (child != null  && child.CompareTag("Wall"))
                {
                    spawnController = child.GetComponent<SpawnController>();
                    if (spawnController != null && spawnController.backroom == 0)
                    {
                        availableWalls.Add(child);
                    }
                }
            }

            while (a < randomNumber)
            {
                for (int i = 0; i < randomNumber; i++)
                {
                    int randomIndex;
                    do
                    {
                        randomIndex = Random.Range(0, availableWalls.Count);
                    } while (chosenIndices.Contains(randomIndex));
                    
                    chosenIndices.Add(randomIndex);
                    Transform randomWall = availableWalls[randomIndex];
                    ReplaceChildren(randomWall);
                    a++;
                }
            } 

        }
        else if (gameObject.tag == "Room_40x10")
        {
            randomNumber = Random.Range(1, 7);

            List<int> chosenIndices = new List<int>();

            a = 0;

            foreach (Transform child in childObjects)
            {
                if (child != null && child.CompareTag("Wall"))
                {
                    spawnController = child.GetComponent<SpawnController>();
                    if (spawnController != null && spawnController.backroom == 0)
                    {
                        availableWalls.Add(child);
                    }
                }
            }

            while (a < randomNumber)
            {
                for (int i = 0; i < randomNumber; i++)
                {
                    int randomIndex;
                    do
                    {
                        randomIndex = Random.Range(0, availableWalls.Count);
                    } while (chosenIndices.Contains(randomIndex));
                    
                    chosenIndices.Add(randomIndex);
                    Transform randomWall = availableWalls[randomIndex];
                    ReplaceChildren(randomWall);
                    a++;
                }
            } 

        }
        else if (gameObject.tag == "Room_20x20")
        {
            randomNumber = Random.Range(1, 3);

            List<int> chosenIndices = new List<int>();

            a = 0;

            foreach (Transform child in childObjects)
            {
                if (child != null && child.CompareTag("Wall"))
                {
                    spawnController = child.GetComponent<SpawnController>();
                    if (spawnController != null && spawnController.backroom == 0)
                    {
                        availableWalls.Add(child);
                    }
                }
            }

            while (a < randomNumber)
            {
                for (int i = 0; i < randomNumber; i++)
                {
                    int randomIndex;
                    do
                    {
                        randomIndex = Random.Range(0, availableWalls.Count);
                    } while (chosenIndices.Contains(randomIndex));
                    
                    chosenIndices.Add(randomIndex);
                    Transform randomWall = availableWalls[randomIndex];
                    ReplaceChildren(randomWall);
                    a++;
                }
            } 
        }
    }

    void DoorCounter()
    {
        foreach (Transform child in childObjects)
        {
            // Проверяем, не равен ли child null
            if (child != null && child.CompareTag("Wall"))
            {
                spawnController = child.GetComponent<SpawnController>();

                if (spawnController != null)
                {
                    wallCount++;
                    
                    int leadRoom = spawnController.leadroom;
                    int backRoom = spawnController.backroom;
                }
            }
        }

        dataManager.SetWallCount(wallCount);
    }
}
