using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossSpawnController : MonoBehaviour
{
    DataManager dataManager;

    private Camera cam;

    private MiniBossVariants MB_variants;

    public int idroom;

    public int backroom;

    public int leadroom;

    public int playerRoomId;

    public int whws;

    public int nextroomid;

    private int rand;

    public bool isleadWall;

    public int returnRoom;

    public Vector3 cameraChangePos;
    public Vector3 playerChangePos;

    Vector3 spawnPosition;

    private GameObject proshRoomCopy;

    private GameObject proshlayaRoom;

    private GameObject sp;

    private GameObject newRoom;

    public MiniBossDirection MB_direction;

    private Transform PresentRoom;

    public enum MiniBossDirection
    {
        Left,
        Right,
        None
    }
    void Start()
    {
        PresentRoom = transform.parent;
        
        dataManager = DataManager.Instance;

        MB_variants = GameObject.FindGameObjectWithTag("MBVariants").GetComponent<MiniBossVariants>();

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
                
                if (MB_direction == MiniBossDirection.Left)
                {
                    other.transform.position -= playerChangePos;
                    cam.transform.position -= cameraChangePos;
                } 
                
                else if (MB_direction == MiniBossDirection.Right)
                {
                    other.transform.position += playerChangePos;
                    cam.transform.position += cameraChangePos;
                }

                leadroom  = 1;

                proshlayaRoom = dataManager.GetGameObject(idroom);
                proshRoomCopy = proshlayaRoom;
                isleadWall = false;
                Invoke("GetObjectActive", 0.1f);
            }
            else if (leadroom == 1)
            {   
                if (MB_direction == MiniBossDirection.Left)
                {
                    other.transform.position -= playerChangePos;
                    cam.transform.position -= cameraChangePos;
                } 
                
                else if (MB_direction == MiniBossDirection.Right)
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
                if (MB_direction == MiniBossDirection.Left)
                {
                    other.transform.position -= playerChangePos;
                    cam.transform.position -= cameraChangePos;
                } 
                
                else if (MB_direction == MiniBossDirection.Right)
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

        if(other.CompareTag("MiniBossWall") && leadroom == 0 && backroom == 0)
        {
            backroom = 1;
            returnRoom = dataManager.GetLastRoomId();
        }     
    }      

    public void Spawn()
    {
        newRoom = null;

        sp = dataManager.GetGameObject(idroom);

        rand = Random.Range(0, MB_variants.MiniBossRooms.Length);

        proshRoomCopy = MB_variants.MiniBossRooms[rand];
              
        if (MB_direction == MiniBossDirection.Left)
        {
            if (sp.tag == "Room_40x10")
            {
                spawnPosition = PresentRoom.position - new Vector3(40f, 0, 0);
            }
            else if (sp.tag == "Room_20x10")
            {
                if (proshRoomCopy.tag == "BossRoom")
                {
                    spawnPosition = PresentRoom.position - new Vector3(40f, 0, 0);
                }
            }
            else if (sp.tag == "Room_20x20")
            {
                spawnPosition = PresentRoom.position - new Vector3(40f, +17f, 0);
            }
            else if (sp.tag == "Room_40x20_Hor")
            {
                spawnPosition = PresentRoom.position - new Vector3(50f, +5f, 0);
            }  
        }
        
        else if (MB_direction == MiniBossDirection.Right)
        {   
            if (sp.tag == "Room_40x10")
            {
                spawnPosition = PresentRoom.position + new Vector3(40f, 0, 0);
            }
            else if (sp.tag == "Room_20x10")
            {
                if (proshRoomCopy.tag == "BossRoom")
                {
                    spawnPosition = PresentRoom.position + new Vector3(20f, 0, 0);
                }
            }
            else if (sp.tag == "Room_20x20")
            {
               spawnPosition = PresentRoom.position + new Vector3(20f, -17f, 0);
            }
            else if (sp.tag == "Room_40x20_Hor")
            {
                spawnPosition = PresentRoom.position + new Vector3(30f, -5f, 0);
            } 
        }

        newRoom = Instantiate(MB_variants.MiniBossRooms[rand], spawnPosition, Quaternion.identity);

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