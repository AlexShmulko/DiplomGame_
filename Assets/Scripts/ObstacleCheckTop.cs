using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleCheckTop : MonoBehaviour
{
    [SerializeField] private GameObject hero;
    public float heroJumpLenght;

    private void Start()
    {
        heroJumpLenght = 5f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "ObstacleTop")
        {
            heroJumpLenght = Math.Abs(hero.transform.position.y - collision.bounds.center.y) - 1;
            Debug.Log(heroJumpLenght);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "ObstacleTop")
        {
            heroJumpLenght = 5f;
        }
    }
}
