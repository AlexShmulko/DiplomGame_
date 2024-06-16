using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroContact : MonoBehaviour
{

    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private SaveManager saveManager;
    private int originalLayer;

    private void Start()
    {
        originalLayer = gameObject.layer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Robber") == true)
        {
            rb.AddForce(transform.right.x * new Vector2(80f, -30f));
            gameObject.layer = LayerMask.NameToLayer("Hero");
            StartCoroutine(Cor());
        }
    }

    IEnumerator Cor()
    {
        yield return new WaitForSeconds(2f);
        gameObject.layer = originalLayer;
    }


}
