using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnController : MonoBehaviour
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

    public BottomDirection bottomDirection;
    
    private Transform PresentRoom;

    public enum Direction
    {
        SmallTop,
        SmallBottom,
        SmallLeft,
        SmallRight,
        None
    }

    public enum BottomDirection
    {
        BottomLeft,
        Bottom,
        BottomRight,
        None
    }

    void Start()
    {
        PresentRoom = transform.parent;

        dataManager = DataManager.Instance;

        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomsVariants>();

        idroom = dataManager.GetRoomId();

        cam = Camera.main.GetComponent<Camera>();
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

        sp = dataManager.GetGameObject(idroom);

        rand = Random.Range(0, variants.Rooms.Length);

        proshRoomCopy = variants.Rooms[rand];

        if (direction == Direction.SmallLeft || direction == Direction.SmallRight)
        {
            while(proshRoomCopy.tag == "Room_40x20_Ver")
            {
                rand = Random.Range(0, variants.Rooms.Length);
                proshRoomCopy = variants.Rooms[rand];
            }
        }
        else if (direction == Direction.SmallTop || direction == Direction.SmallBottom)
        {
            while(proshRoomCopy.tag == "Room_40x20_Hor")
            {
                rand = Random.Range(0, variants.Rooms.Length);
                proshRoomCopy = variants.Rooms[rand];
            }
        }
        
        if (direction == Direction.SmallLeft || direction == Direction.SmallRight)
        {
            while(proshRoomCopy.tag == "Room_20x20_Ver")
            {
                rand = Random.Range(0, variants.Rooms.Length);
                proshRoomCopy = variants.Rooms[rand];
            }
        }

        if (direction == Direction.SmallTop)
        {   
            if (sp.tag == "Room_20x20")
            {
                if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 20f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 3f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 3f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Ver")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 15f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20_Ver")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 20f, 0);
                }
            }
            else if (sp.tag == "Room_40x10")
            {
                if (bottomDirection == BottomDirection.Bottom)
                { 
                    if (proshRoomCopy.tag == "Room_20x10")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(10f, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x10")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(0f, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(10f, 27f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x20_Ver")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(10f, 22f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20_Ver")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(10f, 27f, 0);
                    }
                }
                else if (bottomDirection == BottomDirection.BottomLeft)
                {
                    if (proshRoomCopy.tag == "Room_20x10")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(0, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x10")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(0f, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(0f, 27f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x20_Ver")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(0f, 22f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20_Ver")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(0f, 27f, 0);
                    }
                }
                else if (bottomDirection == BottomDirection.BottomRight)
                {
                    if (proshRoomCopy.tag == "Room_20x10")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(20f, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x10")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(0f, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(20f, 27f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x20_Ver")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(20f, 22f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20_Ver")
                    {
                        spawnPosition = PresentRoom.position + new Vector3(20f, 27f, 0);
                    }
                }
            }
            else if (sp.tag == "Room_20x10")
            {
                if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0, 10f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 10f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 27f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Ver")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 22f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20_Ver")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 27f, 0);
                }
            }
            else if (sp.tag == "Room_40x20_Ver")
            {
                if (proshRoomCopy.tag == "Room_40x20_Ver")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 39f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0, 27f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0, 27f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 44f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20_Ver")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 44f, 0);
                }
            }
            else if (sp.tag == "Room_20x20_Ver")
            {
                if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 20f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 3f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 3f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Ver")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 15f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20_Ver")
                {
                    spawnPosition = PresentRoom.position + new Vector3(0f, 20f, 0);
                }
            }
        }
        
        else if (direction == Direction.SmallBottom)
        {   
            if (sp.tag == "Room_20x20")
            {   
                if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 20f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 27f, 0);
                } 
                else if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 27f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Ver")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 44f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20_Ver")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 20f, 0);
                }
            }
            else if (sp.tag == "Room_20x20_Ver")
            {   
                if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 20f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20_Ver")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 20f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 27f, 0);
                } 
                else if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 27f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Ver")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 44f, 0);
                }
            }
            else if (sp.tag == "Room_20x10")
            {
                if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0, 10f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 10f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 3f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Ver")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 27f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20_Ver")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 3f, 0);
                }
            }
            else if (sp.tag == "Room_40x10")
            {
                if (bottomDirection == BottomDirection.Bottom)
                {
                    if (proshRoomCopy.tag == "Room_20x10")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(-10f, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x10")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(0f, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(-10f, 3f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x20_Ver")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(-10f, 27f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20_Ver")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(-10f, 3f, 0);
                    }
                }
                else if (bottomDirection == BottomDirection.BottomLeft)
                {
                    if (proshRoomCopy.tag == "Room_20x10")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(0, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x10")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(0f, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(0f, 3f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x20_Ver")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(0f, 27f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20_Ver")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(0f, 3f, 0);
                    }
                }
                else if (bottomDirection == BottomDirection.BottomRight)
                {
                    if (proshRoomCopy.tag == "Room_20x10")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(-20f, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x10")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(0f, 10f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(-20f, 3f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_40x20_Ver")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(-20f, 27f, 0);
                    }
                    else if (proshRoomCopy.tag == "Room_20x20_Ver")
                    {
                        spawnPosition = PresentRoom.position - new Vector3(-20f, 3f, 0);
                    }
                }
            }
            else if (sp.tag == "Room_40x20_Ver")
            {
                if (proshRoomCopy.tag == "Room_40x20_Ver")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 39f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0, 22f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 22f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 15f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20_Ver")
                {
                    spawnPosition = PresentRoom.position - new Vector3(0f, 15f, 0);
                }
            }
        } 
        
        else if (direction == Direction.SmallLeft)
        {
            if (sp.tag == "Room_40x10")
            {
                if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(20f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(40f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position - new Vector3(20f, -17f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Hor")
                {
                    spawnPosition = PresentRoom.position - new Vector3(30f, -5f, 0);
                }
            }
            else if (sp.tag == "Room_20x10")
            {
                if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(40f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(20f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position - new Vector3(20f, -17f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Hor")
                {
                    spawnPosition = PresentRoom.position - new Vector3(30f, -5f, 0);
                }
            }
            else if (sp.tag == "Room_20x20")
            {
                if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(40f, 17f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(20f, 17f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position - new Vector3(20f, 0, 0); 
                }
                else if (proshRoomCopy.tag == "Room_40x20_Hor")
                {
                    spawnPosition = PresentRoom.position - new Vector3(30f, 12f, 0);
                }
            }
            else if (sp.tag == "Room_40x20_Hor")
            {
                if (proshRoomCopy.tag == "Room_40x20_Hor")
                {
                    spawnPosition = PresentRoom.position - new Vector3(40f, 0f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(30f, 5f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position - new Vector3(50f, 5f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position - new Vector3(30f, -12f, 0);
                }
            }  
        }
        
        else if (direction == Direction.SmallRight)
        {   
            if (idroom == 0)
            {   
                if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(20f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(20f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position + new Vector3(20f, 17f, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Hor")
                {
                    spawnPosition = PresentRoom.position + new Vector3(30f, 5f, 0);
                }
            }
            else if (sp.tag == "Room_40x10")
            {
                if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(40f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(40f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position + new Vector3(40f, 17, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Hor")
                {
                    spawnPosition = PresentRoom.position + new Vector3(50f, 5f, 0);
                }
            }
            else if (sp.tag == "Room_20x10")
            {
                if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(20f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(20f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position + new Vector3(20f, 17, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Hor")
                {
                    spawnPosition = PresentRoom.position + new Vector3(30f, 5f, 0);
                }
            }
            else if (sp.tag == "Room_20x20")
            {
                if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(20f, -17f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(20f, -17f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position + new Vector3(20f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_40x20_Hor")
                {
                    spawnPosition = PresentRoom.position + new Vector3(30f, -12f, 0);
                }
            }
            else if (sp.tag == "Room_40x20_Hor")
            {
                if (proshRoomCopy.tag == "Room_40x20_Hor")
                {
                    spawnPosition = PresentRoom.position + new Vector3(40f, 0, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(30f, -5f, 0);
                }
                if (proshRoomCopy.tag == "Room_40x10")
                {
                    spawnPosition = PresentRoom.position + new Vector3(30f, -5f, 0);
                }
                else if (proshRoomCopy.tag == "Room_20x20")
                {
                    spawnPosition = PresentRoom.position + new Vector3(30f, 12f, 0);
                }
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
