using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robber : MonoBehaviour
{
    public int robberHP = 100;
    public int souls = 3;
    private SaveManager saveManager;
    public GameObject soul;

    private void Start()
    {
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    public void TakeDamage()
    {
        robberHP = robberHP - saveManager.heroDamage;
        if (robberHP < 0) 
        {
            Instantiate(soul, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
