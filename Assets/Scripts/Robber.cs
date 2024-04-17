using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robber : MonoBehaviour
{
    public int robberHP = 100;
    public int souls = 3;
    private HeroStats heroStats;
    public GameObject soul;

    private void Start()
    {
        heroStats = GameObject.Find("Hero").GetComponent<HeroStats>();
    }

    public void TakeDamage()
    {
        robberHP = robberHP - heroStats.damage;
        if (robberHP < 0) 
        {
            Destroy(gameObject);
            //Instantiate(soul);
        }
    }
}
