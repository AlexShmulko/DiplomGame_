using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isFalling = true;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Ground")
        {
            isFalling = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isFalling = false;
        }
    }

}
