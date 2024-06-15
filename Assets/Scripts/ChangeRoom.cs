using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{

    public Vector3 cameraChangePos;
    public Vector3 playerChangePos;
    private Camera cam;
    
    DataManager dataManager;

    public int checkNewRoom = 0;

    public int playerRoomId;

    public int returnRoom;

    //public wallController

    public int lri;

    public int nri;

    public float teleportDistance = 5f;

    public int whws;

    public bool isSpawned = false;

    void Start()
    {
        dataManager = DataManager.Instance;

        playerRoomId = dataManager.GetRoomId();

        cam = Camera.main.GetComponent<Camera>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            if (!isSpawned)
            {
                dataManager.SetLastRoomId(playerRoomId);
                checkNewRoom = 1;
                playerRoomId++;
                dataManager.SetRoomId(playerRoomId);
                returnRoom = 0;
                isSpawned = true;
                //other.transform.position += playerChangePos;
                //cam.transform.position += cameraChangePos;
            }
            //else
            //{
                /*playerRoomId--;
                dataManager.SetRoomId(playerRoomId);
                other.transform.position -= playerChangePos;
                cam.transform.position -= cameraChangePos;*/
            //}
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            ChangeRoom changeRoomScript = gameObject.GetComponent<ChangeRoom>();
            if (rb != null && changeRoomScript != null)
            {
                // Телепортируем объект влево на определенное расстояние
                rb.position += Vector2.left * teleportDistance;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            checkNewRoom = 0;
        }

        if(other.CompareTag("Trigger1"))
        {
            
        }
    }
}
