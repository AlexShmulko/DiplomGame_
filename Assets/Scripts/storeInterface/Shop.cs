using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private HeroStates heroStates;

    private void Start()
    {
        heroStates = GameObject.Find("Hero").GetComponent<HeroStates>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) heroStates.inShopZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) heroStates.inShopZone = false;
    }
}
