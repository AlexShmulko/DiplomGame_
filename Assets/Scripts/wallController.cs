using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallController : MonoBehaviour
{
    DataManager dataManager;

    public Vector3 cameraChangePos;
    public Vector3 playerChangePos;
    private Camera cam;

    public int idroom;

    private RoomsVariants variants;

    public int whws;

    private GameObject proshlayaRoom;

    private GameObject newRoom;

    public int checkNewRoom = 0;

    public int playerRoomId;

    public int returnRoom;

    public int tecroomid;

    public int nextroomid;

    public float teleportDistance = 5f;

    public int leadroom;

    public int backroom;

    public bool isBackWall;

    public bool isleadWall;

    public GameObject blablakeka;

    private GameObject sp;

    public bool isSpawned = false;

    public Direction direction;

    //public GameObject PresentRoom;
    
    private Transform PresentRoom;

    public enum Direction
    {
        SmallTop,
        SmallBottom,
        SmallLeft,
        SmallRight,
        None
    }

    void Start()
    {
        PresentRoom = transform.parent;

        dataManager = DataManager.Instance;

        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomsVariants>();

        idroom = dataManager.GetRoomId();

        //dataManager.SetRoomId(0);

        cam = Camera.main.GetComponent<Camera>();

        sp = GameObject.FindGameObjectWithTag("RoomPoint");

        Debug.Log(sp.name + sp.tag);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {

            if (leadroom == 0 && backroom == 0)
            {   
                dataManager.SetLastRoomId(idroom);
                whws = dataManager.GetLastRoomId();
                //checkNewRoom = 1;
                //dataManager.SetMyVariable(checkNewRoom);
                playerRoomId = dataManager.GetRoomId();
                playerRoomId++;
                dataManager.SetRoomId(playerRoomId);
                nextroomid = playerRoomId;
                Spawn();
                //isSpawned = true;
                other.transform.position += playerChangePos;
                cam.transform.position += cameraChangePos;
                leadroom  = 1;
                proshlayaRoom = dataManager.GetGameObject(idroom);
                blablakeka = proshlayaRoom;
                isleadWall = false;
                Invoke("Blablakek", 0.5f);
                
            }else if (leadroom == 1)
            {
                other.transform.position += playerChangePos;
                cam.transform.position += cameraChangePos;
                proshlayaRoom = dataManager.GetGameObject(nextroomid);
                blablakeka = proshlayaRoom;
                isleadWall = true;
                Blablakek();
                proshlayaRoom = dataManager.GetGameObject(idroom);
                blablakeka = proshlayaRoom;
                isleadWall = false;
                Invoke("Blablakek", 0.5f);
            }

            else if (leadroom == 0 && backroom == 1)
            {   
                other.transform.position -= playerChangePos;
                cam.transform.position -= cameraChangePos;
                proshlayaRoom = dataManager.GetGameObject(returnRoom);
                blablakeka = proshlayaRoom;
                isleadWall = true;
                Blablakek();
                proshlayaRoom = dataManager.GetGameObject(idroom);
                blablakeka = proshlayaRoom;
                isleadWall = false;
                Invoke("Blablakek", 0.5f);
            }

            
        }

        if(other.CompareTag("Wall") && leadroom == 0 && backroom == 0)
        {
            backroom = 1;
            returnRoom = dataManager.GetLastRoomId();
        }

        if(other.CompareTag("Wall") && leadroom == 1)
        {
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {   
        if(other.CompareTag("Player"))
        {
            Debug.Log("jojaidjaf");
            checkNewRoom = 0;
            dataManager.SetMyVariable(checkNewRoom);
        }

        if(other.CompareTag("Trigger1"))
        {
            
        }
    }

    public void Spawn()
    {
        newRoom = null;

        Vector3 spawnPosition = PresentRoom.position + new Vector3(20f, 0, 0);

        newRoom = Instantiate(variants.Rooms[0], spawnPosition, Quaternion.identity);

        dataManager.AddGameObject(nextroomid, newRoom);

    }

    void Blablakek()
    {
        SetObjectActive(blablakeka, isleadWall);
    }

    void SetObjectActive(GameObject gameObject, bool isactive)
    {
        gameObject.SetActive(isactive);
    }
    
}
