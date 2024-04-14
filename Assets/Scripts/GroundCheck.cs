using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isFalling = true;
    public string groundType = "Ground";

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Ground" || collision.transform.tag == "Platform")
        {
            isFalling = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "Platform")
        {
            isFalling = false;
        }
        if (collision.transform.tag == "Ground")
        {
            groundType = "Ground";
        }
        if (collision.transform.tag == "Platform")
        {
            groundType = "Platform";
        }
    }

}
