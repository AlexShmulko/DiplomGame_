using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    private SpawnController spawnController;

    private Transform[] childObjects;

    public GameObject newObjectPrefab;

    private int randomNumber;

    private int a;

    DataManager dataManager;

    private int wallCount;

    void Start()
    {
        dataManager = DataManager.Instance;

        StartCoroutine(StartAfterDelay(0.2f));
    }

    IEnumerator StartAfterDelay(float delay)
    {
        // Ждем указанное количество секунд
        yield return new WaitForSeconds(delay);

        // Получаем компонент SpawnController из дочерних объектов
        childObjects = GetComponentsInChildren<Transform>();

        List<Transform> availableWalls = new List<Transform>();

        //wallCount = dataManager.GetWallCount();

        //Debug.Log(wallCount);

        foreach (Transform child in childObjects)
        {
            if (child.CompareTag("Wall"))
            {
                spawnController = child.GetComponent<SpawnController>();

                if (spawnController != null)
                {
                    wallCount++;
                    
                    // Если компонент SpawnController найден, выводим информацию
                    int leadRoom = spawnController.leadroom;
                    int backRoom = spawnController.backroom;

                    Debug.Log("Room Name: " + gameObject.name + ", Wall Object: " + child.name + ", Lead Room: " + leadRoom.ToString() + ", Back Room: " + backRoom.ToString());
                }
                else
                {
                    Debug.LogWarning("SpawnController component not found on GameObject with tag 'Wall'.");
                }
            }
        }

        if (gameObject.tag == "Room_20x10")
        {
            randomNumber = Random.Range(1, 3);

            List<int> chosenIndices = new List<int>();

            a = 0;

            foreach (Transform child in childObjects)
            {
                if (child.CompareTag("Wall"))
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
                if (child.CompareTag("Wall"))
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
                if (child.CompareTag("Wall"))
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

        dataManager.SetWallCount(wallCount);
        Debug.Log("asd " + wallCount);
    }

    void ReplaceChildren(Transform child)
    {
        Transform parent = child.parent;

        Vector3 position = child.position;
        Quaternion rotation = child.rotation;

        GameObject newObject = Instantiate(newObjectPrefab, position, rotation);

        newObject.transform.parent = parent;
        
        Destroy(child.gameObject);

        //CopyComponents(child.gameObject, newObject);
    }

    /*void CopyComponents(GameObject oldObject, GameObject newObject)
    {
        // Получаем все компоненты текущего объекта
        Component[] components = oldObject.GetComponents<Component>();

        // Копируем компоненты на новый объект
        foreach (Component comp in components)
        {
            // Проверяем, не является ли компонентом трансформация
            if (!(comp is Transform))
            {
                // Копируем компоненты, кроме Transform, на новый объект
                UnityEditorInternal.ComponentUtility.CopyComponent(comp);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(newObject);
            }
        }
    }*/

}
