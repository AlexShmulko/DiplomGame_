using UnityEngine;
using System.Collections.Generic; 

public class DataManager : MonoBehaviour
{
    private int myVariable;

    private int roomId;

    private int wallCount;

    private int lastRoomId;

    private bool isMiniBossRoomSpawned;

    private int TakenDamage;

    private int roomScore;

    private Dictionary<int, GameObject> gameObjectsDictionary = new Dictionary<int, GameObject>();

    private static DataManager instance;

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("DataManager").AddComponent<DataManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    /*private void Awake()
    {
        // Пример создания массива из 10 игровых объектов при инициализации DataManager
        gameObjectsArray = new GameObject[10];
    }*/

    public void SetIsMiniBossRoomSpawned (bool value)
    {
        isMiniBossRoomSpawned = value;
    }

    public bool GetIsMiniBossRoomSpawned()
    {
        return isMiniBossRoomSpawned;
    }

    public void SetWallCount(int value)
    {
        wallCount = value;
    }

    public int GetWallCount()
    {
        return wallCount;
    }
    public void SetRoomScore(int value)
    {
        roomScore = value;
    }

    public int GetRoomScore()
    {
        return roomScore;
    }

    public void SetDamage(int value)
    {
        TakenDamage = value;
    }

    public int GetDamage()
    {
        return TakenDamage;
    }

    // Публичный метод для установки значения переменной
    public void SetMyVariable(int value)
    {
        myVariable = value;
    }

    // Публичный метод для получения значения переменной
    public int GetMyVariable()
    {
        return myVariable;
    }

    public void SetRoomId(int value)
    {
        roomId = value;
    }

    // Публичный метод для получения значения переменной
    public int GetRoomId()
    {
        return roomId;
    }

    public void SetLastRoomId(int value)
    {
        lastRoomId = value;
    }

    // Публичный метод для получения значения переменной
    public int GetLastRoomId()
    {
        return lastRoomId;
    }

    // Публичный метод для добавления игрового объекта в словарь
    public void AddGameObject(int index, GameObject obj)
    {
        // Проверяем, есть ли уже объект с таким индексом
        if (gameObjectsDictionary.ContainsKey(index))
        {
            Debug.LogError("An object with index " + index + " already exists in the dictionary.");
            return;
        }
        
        // Добавляем объект в словарь
        gameObjectsDictionary.Add(index, obj);
    }

    // Публичный метод для получения игрового объекта из словаря по индексу
    public GameObject GetGameObject(int index)
    {
        // Проверяем, есть ли объект с таким индексом
        if (gameObjectsDictionary.ContainsKey(index))
        {
            return gameObjectsDictionary[index];
        }
        else
        {
            Debug.LogError("No object with index " + index + " found in the dictionary.");
            return null;
        }
    }
}
