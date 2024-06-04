using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDiscription : MonoBehaviour
{
    public GameObject discription;

    private void Start()
    {
        discription.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) discription.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) discription.SetActive(false);
    }
}
