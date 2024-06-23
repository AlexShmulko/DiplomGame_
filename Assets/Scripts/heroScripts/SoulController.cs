using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulController : MonoBehaviour
{

    private SaveManager saveManager;
    private int violetStones;

    public int soulPrice;

    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Soul"))
        {
            Debug.Log("bjkabjksdad" + saveManager.violotStones);
            soulPrice = 20 + saveManager.violotStones * 10;
            Destroy(collision.gameObject);
            saveManager.souls += soulPrice;
            saveManager.SaveData();            
        }
    }
}
