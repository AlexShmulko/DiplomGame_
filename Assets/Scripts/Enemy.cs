using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SaveManager saveManager;

    public int hp = 100;
    public int souls = 3;

    void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    public void TakeDamage()
    {
        hp -= saveManager.heroDamage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
