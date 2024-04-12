using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    private RoomsVariants variants;

    private GameObject startRoom;

    private GameObject PresentRoom;

    private WallDirection Direction;

    private wallController changeRoom;

    private GameObject spawner;

    private GameObject newRoom;

    private Transform spawnerTransform;

    DataManager dataManager;

    private bool spawned = false;

    public int lri;

    public int nri;

    public int a = 0;

    void Start()
    {
        dataManager = DataManager.Instance;

        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomsVariants>();

        startRoom = GameObject.FindGameObjectWithTag("StartRoom");

        dataManager.AddGameObject(0, startRoom);

        dataManager.SetRoomId(0);

        //spawner = GameObject.FindGameObjectWithTag("RoomPoint");

        //spawnerTransform = startRoom.transform.Find("RoomPoint");

        //spawnerTransform = spawner.transform;

        PresentRoom = startRoom;

        //Debug.Log(PresentRoom.name + " " + PresentRoom.tag);
    } 

    void FixedUpdate()
    {

        
        a = dataManager.GetMyVariable();
        Debug.Log(a + "это а");

        if (a == 1)
        {
            spawned = false;
            //Spawn();
            a = 0;
        }
        else
        {
           
        }   
    }

    public void Spawn()
    {
        if (!spawned && a == 1)
        {
            newRoom = null;

            Vector3 spawnPosition = PresentRoom.transform.position + new Vector3(20f, 0, 0);

            newRoom = Instantiate(variants.Rooms[0], spawnPosition, Quaternion.identity);

            //dataManager.AddGameObject(dataManager.GetRoomId(), newRoom);

            //GameObject asd =  dataManager.GetGameObject(1);

            //Debug.Log(asd.name + " " + asd.tag);

            spawned = true;

            PresentRoom = newRoom;

            //startRoom.SetActive(false);
        }
    }
}
