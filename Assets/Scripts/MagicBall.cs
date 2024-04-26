using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    private Rigidbody2D magicBallRb;
    public GameObject magicImpact;
    public float magicBallSpeed = 15f;

    void Start()
    {
        magicBallRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        magicBallRb.velocity = transform.right * magicBallSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage();
        }
        Instantiate(magicImpact, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

}
