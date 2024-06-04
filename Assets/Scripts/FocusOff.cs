using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOff : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    public Camera cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cinemachine.Follow = transform;
            cam.GetComponent<CamMove>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        cinemachine.Follow = GameObject.Find("Hero").transform;
        cam.GetComponent<CamMove>().enabled = true;
    }
}
