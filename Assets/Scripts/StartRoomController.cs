using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoomController : MonoBehaviour
{
    private GameObject startRoom;

    private GameObject PresentRoom;

    DataManager dataManager;

    void Start()
    {
        dataManager = DataManager.Instance;

        startRoom = GameObject.FindGameObjectWithTag("StartRoom");

        dataManager.AddGameObject(0, startRoom);

        dataManager.SetRoomId(0);

        PresentRoom = startRoom;
    }   
}
