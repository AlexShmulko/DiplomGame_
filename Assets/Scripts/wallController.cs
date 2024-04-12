using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class wallController : MonoBehaviour
{
    DataManager dataManager;

    public Vector3 cameraChangePos;
    public Vector3 playerChangePos;

    Vector3 spawnPosition;

    private Camera cam;

    public int idroom;

    private int rand;

    private RoomsVariants variants;

    public int whws;

    private GameObject proshlayaRoom;

    private GameObject newRoom;

    public int playerRoomId;

    public int returnRoom;

    public int nextroomid;

    public float teleportDistance = 5f;

    public int leadroom;

    public int backroom;

    public bool isBackWall;

    public bool isleadWall;

    private GameObject proshRoomCopy;

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

        cam = Camera.main.GetComponent<Camera>();

        /*rand = Random.Range(0, variants.Rooms.Length);  

        proshRoomCopy = variants.Rooms[rand];

        Debug.Log(proshRoomCopy.tag + " " + proshRoomCopy.name);
        */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {

            if (leadroom == 0 && backroom == 0)
            {   
                dataManager.SetLastRoomId(idroom);
                whws = dataManager.GetLastRoomId();

                playerRoomId = dataManager.GetRoomId();
                playerRoomId++;
                dataManager.SetRoomId(playerRoomId);
                nextroomid = playerRoomId;

                Spawn();

                if (direction == Direction.SmallTop)
                {
                    other.transform.position += playerChangePos;
                    cam.transform.position += cameraChangePos;
                }

                else if (direction == Direction.SmallBottom)
                {
                    other.transform.position -= playerChangePos;
                    cam.transform.position -= cameraChangePos;
                } 
                
                else if (direction == Direction.SmallLeft)
                {
                    other.transform.position -= playerChangePos;
                    cam.transform.position -= cameraChangePos;
                } 
                
                else if (direction == Direction.SmallRight)
                {
                    other.transform.position += playerChangePos;
                    cam.transform.position += cameraChangePos;
                }

                leadroom  = 1;

                proshlayaRoom = dataManager.GetGameObject(idroom);
                proshRoomCopy = proshlayaRoom;
                isleadWall = false;
                Invoke("GetObjectActive", 0.1f);
                
            }else if (leadroom == 1)
            {   
                if (direction == Direction.SmallTop)
                {
                    other.transform.position += playerChangePos;
                    cam.transform.position += cameraChangePos;
                }

                else if (direction == Direction.SmallBottom)
                {
                    other.transform.position -= playerChangePos;
                    cam.transform.position -= cameraChangePos;
                } 
                
                else if (direction == Direction.SmallLeft)
                {
                    other.transform.position -= playerChangePos;
                    cam.transform.position -= cameraChangePos;
                } 
                
                else if (direction == Direction.SmallRight)
                {
                    other.transform.position += playerChangePos;
                    cam.transform.position += cameraChangePos;
                }

                proshlayaRoom = dataManager.GetGameObject(nextroomid);
                proshRoomCopy = proshlayaRoom;
                isleadWall = true;
                GetObjectActive();

                proshlayaRoom = dataManager.GetGameObject(idroom);
                proshRoomCopy = proshlayaRoom;
                isleadWall = false;
                Invoke("GetObjectActive", 0.1f);
            }

            else if (leadroom == 0 && backroom == 1)
            {   
                if (direction == Direction.SmallTop)
                {
                    other.transform.position += playerChangePos;
                    cam.transform.position += cameraChangePos;
                }

                else if (direction == Direction.SmallBottom)
                {
                    other.transform.position -= playerChangePos;
                    cam.transform.position -= cameraChangePos;
                } 
                
                else if (direction == Direction.SmallLeft)
                {
                    other.transform.position -= playerChangePos;
                    cam.transform.position -= cameraChangePos;
                } 
                
                else if (direction == Direction.SmallRight)
                {
                    other.transform.position += playerChangePos;
                    cam.transform.position += cameraChangePos;
                }

                proshlayaRoom = dataManager.GetGameObject(returnRoom);
                proshRoomCopy = proshlayaRoom;
                isleadWall = true;
                GetObjectActive();

                proshlayaRoom = dataManager.GetGameObject(idroom);
                proshRoomCopy = proshlayaRoom;
                isleadWall = false;
                Invoke("GetObjectActive", 0.1f);
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
            
        }
    }

    public void Spawn()
    {
        newRoom = null;

        rand = Random.Range(0, variants.Rooms.Length);

        proshRoomCopy = variants.Rooms[rand];

        if (direction == Direction.SmallTop)
        {
            if (proshRoomCopy.tag == "Room_20x10")
            {
                spawnPosition = PresentRoom.position + new Vector3(0, 10f, 0);
            }
        }

        else if (direction == Direction.SmallBottom)
        {
            if (proshRoomCopy.tag == "Room_20x10")
            {
                spawnPosition = PresentRoom.position - new Vector3(0, 10f, 0);
            }
        } 
        
        else if (direction == Direction.SmallLeft)
        {
            if (proshRoomCopy.tag == "Room_20x10")
            {
                spawnPosition = PresentRoom.position - new Vector3(20f, 0, 0);
            }
        } 
        
        else if (direction == Direction.SmallRight)
        {
            if (proshRoomCopy.tag == "Room_20x10")
            {
                spawnPosition = PresentRoom.position + new Vector3(20f, 0, 0);
            }
        }

        newRoom = Instantiate(variants.Rooms[rand], spawnPosition, Quaternion.identity);

        dataManager.AddGameObject(nextroomid, newRoom);
    }    

    void GetObjectActive()
    {
        SetObjectActive(proshRoomCopy, isleadWall);
    }

    void SetObjectActive(GameObject gameObject, bool isactive)
    {
        gameObject.SetActive(isactive);
    }
    
}
