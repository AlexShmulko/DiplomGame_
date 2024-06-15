using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D called with: " + collision.gameObject.name);
        HeroTakeDamage hero = collision.GetComponent<HeroTakeDamage>();
        if (hero != null)
        {
            Debug.Log("Hero detected");
            hero.TakeDamage(20);
        }
    }
}
