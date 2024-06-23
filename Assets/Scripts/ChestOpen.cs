using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    private Animator animator;
    private HeroStates heroStates;
    private SaveManager saveManager;
    private bool isOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        heroStates = GameObject.Find("Hero").GetComponent<HeroStates>();
        saveManager = GameObject.Find("SaveManager").GetComponent<SaveManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isOpen)
        {
            if (Input.GetKeyDown(KeyCode.F) && heroStates.inChestZone)
            {
                saveManager.coins += 500 * saveManager.orangeStones;
                saveManager.SaveData();
                animator.Play("openGoldChest");
                isOpen = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            heroStates.inChestZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            heroStates.inChestZone = false;
        }
    }
}
