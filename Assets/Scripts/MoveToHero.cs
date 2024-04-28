using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToHero : MonoBehaviour
{
    public Transform heroTransorm;
    //public Collider2D heroCollider;
    //public GameObject hero;

    private void Start()
    {
        heroTransorm = GameObject.Find("Hero").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, heroTransorm.position, 3.5f * Time.deltaTime);
    }
}
