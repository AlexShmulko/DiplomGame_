using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public SpawnEnemiesController sec;
    public int robberHP;
    public int souls;
    private SaveManager saveManager;
    public GameObject soul;
    public bool isDead = false;

    private void Start()
    {   
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
        sec = GameObject.FindGameObjectWithTag("RoomPoint").GetComponent<SpawnEnemiesController>();
    }

    public void TakeDamage()
    {
        robberHP = robberHP - saveManager.heroDamage;
        if (robberHP < 0)
        {
            for (int i = 0; i < souls; i++)
            {
                Instantiate(soul, gameObject.transform.position, gameObject.transform.rotation);
            }
            isDead = true;
        }
    }

}
