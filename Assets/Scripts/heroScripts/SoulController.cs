using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulController : MonoBehaviour
{

    private SaveManager saveManager;

    public int soulPrice = 20;

    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Soul"))
        {
            Destroy(collision.gameObject);
            saveManager.souls += soulPrice;
            saveManager.SaveData();
        }
    }
}
