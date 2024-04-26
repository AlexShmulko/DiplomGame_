using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator anim;
    private Robber robber;
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.gameObject.CompareTag("barrel"))
        {
            anim = collision.gameObject.GetComponent<Animator>();
            anim.Play("barrelDestruction");
        }
        if (enemy != null)
        {
            enemy.TakeDamage();
        }
    }
}
