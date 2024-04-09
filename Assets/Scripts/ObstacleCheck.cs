using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleCheck : MonoBehaviour
{

    [SerializeField] private GameObject hero;

    private Rigidbody2D heroRb;
    public float heroDeshLenght;

    private void Start()
    {
        heroRb = hero.GetComponent<Rigidbody2D>();
        heroDeshLenght = 3f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            //Debug.Log("?");
            //Debug.Log(heroRb.transform.position.x - collision.bounds.center.x);
            heroDeshLenght = Math.Abs(hero.transform.position.x - collision.bounds.center.x);
            Debug.Log(heroDeshLenght);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            Debug.Log(")");
            heroDeshLenght = 3f;
        }
    }
}
