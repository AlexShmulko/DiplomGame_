using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HeroTakeDamage hero = collision.GetComponent<HeroTakeDamage>();
        if (hero != null)
        {
            Debug.Log("lol");
            hero.TakeDamage(10);
        }
    }
}
