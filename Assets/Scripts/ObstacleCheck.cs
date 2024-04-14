using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleCheck : MonoBehaviour
{
    [SerializeField] private GameObject hero;
    public float heroDeshLenght;

    private void Start()
    {
        heroDeshLenght = 3f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            heroDeshLenght = Math.Abs(hero.transform.position.x - collision.bounds.center.x);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            heroDeshLenght = 3f;
        }
    }
}
