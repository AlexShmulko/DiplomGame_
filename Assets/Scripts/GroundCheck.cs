using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool onGround = true;
    public string groundType;
    public GameObject ground;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "SolidGround" || collision.transform.tag == "SoftGround")
        {
            onGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Oo");
        if (collision.transform.tag == "SolidGround" || collision.transform.tag == "SoftGround")
        {
            onGround = true;
            ground = collision.gameObject;
        }
        if (collision.transform.tag == "SolidGround")
        {
            groundType = "SolidGround";
        }
        if (collision.transform.tag == "SoftGround")
        {
            groundType = "SoftGround";
        }
    }

}
