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
        if (collision.gameObject.CompareTag("barrel"))
        {
            anim = collision.gameObject.GetComponent<Animator>();
            anim.Play("barrelDestruction");
        }
        if (collision.gameObject.CompareTag("Robber"))
        {
            robber = collision.gameObject.GetComponent<Robber>();
            robber.TakeDamage();
        }
    }
}
